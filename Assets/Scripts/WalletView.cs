using System;
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
              //  StartCoroutine(ShowItemMovementAnimation(moneyPrefab,achievement.))
                break;
            case AchievementsTypes.Gem:
                break;
            
        }
    }

    private void SetScore(TextMeshProUGUI goldScore, int walletScore)
    {
        goldScore.text = walletScore.ToString();
        
    }
}
