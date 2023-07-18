using UnityEngine;
[CreateAssetMenu(fileName = "ItemModel" , menuName = "ScriptableObject/ItemModel")]
public class ItemModel : ScriptableObject
{
    [field:SerializeField] public string NameAward { get; private set; }
    [field:SerializeField] public int Id { get; private set; }
    [field:SerializeField] public string Description { get; private set; }
    [field:SerializeField] public Sprite Icon { get; private set; }
}
