using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AchievementsSettings", menuName = "ScriptableObject/AchievementsSettings")]
public class AchievementsSettings : ScriptableObject
{
    
    [SerializeField] private List<AchievementModel> _achievements;
    public List<AchievementModel> Achievements => _achievements;
}
