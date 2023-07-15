using UnityEngine;
[CreateAssetMenu(fileName = "MoneyTypePrefab", menuName = "ScriptableObject/MoneyTypePrefab")]
public class MoneyTypePrefab : ScriptableObject
{
    [field:SerializeField] public Transform Prefab { get; private set; }
    [field:SerializeField] public AchievementsTypes Types { get; private set; }
}
