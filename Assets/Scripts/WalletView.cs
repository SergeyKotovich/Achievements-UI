using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldScore;
    [SerializeField] private TextMeshProUGUI _gemScore;
    [SerializeField] private MoneyTypePrefab[] _moneyTypePrefabs;
    [SerializeField] private Transform _canvasRoot;
    [SerializeField] private Transform _goldRoot;
    [SerializeField] private Transform _gemRoot;
    [SerializeField] private int _itemsCount;
    [SerializeField] private float _itemSpeed;
    [SerializeField] private float _itemSpawnDelay;
    [SerializeField] private float _moneyCalculationTime;

    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        SetScore(_goldScore, _wallet.GoldScore);
        SetScore(_gemScore,_wallet.GemScore);
        
        _wallet.ScoreHandler += OnScoreChanged;
    }

    private void OnScoreChanged(AchievementView achievement, int oldScore, int newScore)
    {
        switch (achievement.Types)
        {
            case AchievementsTypes.Gold:
                var moneyPrefab = _moneyTypePrefabs.First(moneyPrefab => moneyPrefab.Types == AchievementsTypes.Gold);
                StartCoroutine(ShowItemMovementAnimation(moneyPrefab, achievement.AwardRoot, _goldRoot.position));// awardroot взял без позиции
                StartCoroutine(ShowMoneyCalculationAnimation(_goldScore, oldScore, newScore));
                break;
            case AchievementsTypes.Gem:
                moneyPrefab = _moneyTypePrefabs.First(moneyPrefab => moneyPrefab.Types == AchievementsTypes.Gem);
                StartCoroutine(ShowItemMovementAnimation(moneyPrefab, achievement.AwardRoot, _gemRoot.position)); // awardroot взял без позиции
                StartCoroutine(ShowMoneyCalculationAnimation(_gemScore, oldScore, newScore));
                break;
            
        }
    }

    private IEnumerator ShowMoneyCalculationAnimation(TextMeshProUGUI scoreLabel, int oldScore, int newScore)
    {
        var currentTime = 0f;
        while (currentTime<=_moneyCalculationTime)
        {
            var progress = currentTime / _moneyCalculationTime;
            var currentScore = (int)Mathf.Lerp(oldScore, newScore, progress);
            currentTime += Time.deltaTime;
            SetScore(scoreLabel,currentScore);
            yield return null;
        }
        SetScore(scoreLabel,newScore);
    }

    private IEnumerator ShowItemMovementAnimation(MoneyTypePrefab moneyPrefab, Transform achievementAwardRoot, Vector3 goldRootPosition)
    {
        for (int i = 0; i < _itemsCount; i++)
        {
            var item = Instantiate(moneyPrefab.Prefab, _canvasRoot);
            item.transform.position = achievementAwardRoot.position;
            StartCoroutine(MoveItemTo(item, goldRootPosition));
            yield return new WaitForSeconds(_itemSpawnDelay);
        }
    }

    private IEnumerator MoveItemTo(Transform itemPrefab, Vector3 goldRootPosition)
    {
        var distance = Vector3.Distance(itemPrefab.position, goldRootPosition);
        var travelDistance = 0f;

        while (travelDistance<=distance)
        {
            travelDistance = _itemSpeed * Time.deltaTime;
            var currentPosition = Vector3.MoveTowards(itemPrefab.position, goldRootPosition, travelDistance);
            itemPrefab.position = currentPosition;
            distance -= travelDistance;
            yield return null;
        }

        itemPrefab.position = goldRootPosition;
        Destroy(itemPrefab.gameObject);
    }

    private void SetScore(TextMeshProUGUI goldScore, int walletScore)
    {
        goldScore.text = walletScore.ToString();
        
    }

    private void OnDestroy()
    {
        if (_wallet != null)
        {
            _wallet.ScoreHandler -= OnScoreChanged;
        }
        
    }
}
