using System;
using UnityEngine;

public class AchievementScreen : MonoBehaviour
{
    [SerializeField] private AchievementsSettings _achievementsSettings;
    [SerializeField] private AchievementView _achievementPrefab;
    [SerializeField] private RectTransform _panelRoot;
    [SerializeField] private AchievementView _achievementTypeItemPrefab;

    private void Awake()
    {
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
                achievement.Initialize(model);
                break;
            }
            case AchievementsTypes.Gem:
            {
                var achievement = Instantiate(_achievementPrefab, _panelRoot);
                achievement.Initialize(model);
                break;
            }
            case AchievementsTypes.Item:
            {
                var achievement = Instantiate(_achievementTypeItemPrefab, _panelRoot);
                achievement.Initialize(model);
                break;
            }
                
        }
        
    }
}
