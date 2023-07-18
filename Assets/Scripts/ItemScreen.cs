using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _icon;

    private Animator _animator;
    private static readonly int Claim = Animator.StringToHash("claim");


    public void Initialize(ItemModel itemModel)
    {
        _name.text = itemModel.name;
        _description.text = itemModel.Description;
        _icon.sprite = itemModel.Icon;
        _animator = GetComponentInChildren<Animator>();
        ChangeState();
    }

    [UsedImplicitly]
    public void CloseScreen()
    {
        Destroy(gameObject);
    }
    private void ChangeState()
    {
        
        _animator.SetTrigger(Claim);
    }
}
