using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action<AchievementView, int, int> ScoreHandler;
    [field:SerializeField] public int GoldScore { get; private set; }
    [field:SerializeField] public int GemScore { get; private set; }

    public void AddGold(AchievementView achievementView, int delta)
    {
        GoldScore += delta;
        ScoreHandler?.Invoke(achievementView, delta, GoldScore);

    }

    public void AddGem(AchievementView achievementView, int delta)
    {
        GemScore = delta;
        ScoreHandler?.Invoke(achievementView, delta, GemScore);
    }
}
