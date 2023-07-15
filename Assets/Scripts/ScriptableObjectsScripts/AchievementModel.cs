using UnityEngine;
[CreateAssetMenu(fileName = "AchievementModel" , menuName = "ScriptableObject/AchievementModel")]
public class AchievementModel : ScriptableObject
{
    [SerializeField] private string _awardName;
    [SerializeField] private string _awardDescription;
    [SerializeField] private Sprite _awardIcon;
    [SerializeField] private Sprite _awardImage;
    [SerializeField] private string _numberOfResources;
    [SerializeField] private GameObject _prefabButtonClaim;
    [SerializeField] private AchievementsTypes _types;

    public string AwardName => _awardName;
    public string AwardDescription => _awardDescription;
    public Sprite AwardIcon => _awardIcon;
    public Sprite AwardImage => _awardImage;
    public string NumberOfResources => _numberOfResources;
    public GameObject PrefabButtonClaim => _prefabButtonClaim;
    public AchievementsTypes Types => _types;
}
