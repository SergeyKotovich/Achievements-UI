using UnityEngine;
[CreateAssetMenu(fileName = "AchievementModel" , menuName = "ScriptableObject/AchievementModel")]
public class AchievementModel : ScriptableObject
{
    [SerializeField] private string _awardName;
    [SerializeField] private string _awardDescription;
    [SerializeField] private Sprite _awardIcon;
    [SerializeField] private Sprite _awardImage;
    [SerializeField] private int _numberOfResources;
    [SerializeField] private AchievementsTypes _types;

    public string AwardName => _awardName;
    public string AwardDescription => _awardDescription;
    public Sprite AwardIcon => _awardIcon;
    public Sprite AwardImage => _awardImage;
    public int NumberOfResources => _numberOfResources;
    public AchievementsTypes Types => _types;
}
