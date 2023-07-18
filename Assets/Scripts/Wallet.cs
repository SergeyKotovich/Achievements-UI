using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action<AchievementView, int, int> ScoreHandler;
    [field:SerializeField] public int GoldScore { get; private set; }
    [field:SerializeField] public int GemScore { get; private set; }

    public void AddGold(AchievementView achievementView, int delta)
    {
        var oldScore = GoldScore;
        GoldScore = oldScore + delta;
        ScoreHandler?.Invoke(achievementView, oldScore, GoldScore);

    }

    public void AddGem(AchievementView achievementView, int delta)
    {
        var oldScore = GemScore;
        GemScore = oldScore + delta;
        ScoreHandler?.Invoke(achievementView, oldScore, GemScore);
    }
}
