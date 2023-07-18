using System;
using UnityEngine;

public class AchievementScreen : MonoBehaviour
{
    [SerializeField] private AchievementsSettings _achievementsSettings;
    [SerializeField] private AchievementView _achievementPrefab;
    [SerializeField] private RectTransform _panelRoot;
    [SerializeField] private AchievementView _achievementTypeItemPrefab;

    [SerializeField] private WalletView _walletView;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ItemScreenManager _itemScreenManager;

    private void Awake()
    {
        _walletView.Initialize(_wallet);
        var settings = _achievementsSettings.Achievements;
        foreach (var model in settings)
        {
            CreateAchievement(model);
        }
    }

    private void CreateAchievement(AchievementModel model)
    {
        switch (model.Types)
        {
            case AchievementsTypes.Gold:
            {
                var achievement = Instantiate(_achievementPrefab, _panelRoot);
                achievement.Initialize(model,
                    () => _wallet.AddGold(achievement, model.NumberOfResources));
                break;
            }
            case AchievementsTypes.Gem:
            {
                var achievement = Instantiate(_achievementPrefab, _panelRoot);
                achievement.Initialize(model,
                    ()=>_wallet.AddGem(achievement,model.NumberOfResources));
                break;
            }
            case AchievementsTypes.Item:
            {
                var achievement = Instantiate(_achievementTypeItemPrefab, _panelRoot);
                achievement.Initialize(model,
                ()=> _itemScreenManager.AddItem(model.NumberOfResources));
                break;
            }
                
        }
        
    }
}
