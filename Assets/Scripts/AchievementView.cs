using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameAward;
    [SerializeField] private TextMeshProUGUI _descriptionAward;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _imageAward;
    [SerializeField] private TextMeshProUGUI _numberOfResources;
    public AchievementsTypes Types { get; private set; }
    public Transform AwardRoot => _imageAward.transform;

    private Action _onAwardClaimed;
    private Animator _animator;
    private bool _isClaimed;



    public void Initialize(AchievementModel achievementModel)
    {
        _nameAward.text = achievementModel.AwardName; 
        _descriptionAward.text = achievementModel.AwardDescription;
        _icon.sprite = achievementModel.AwardIcon;
        _imageAward.sprite = achievementModel.AwardImage;
        _numberOfResources.text = achievementModel.NumberOfResources;
        Types = achievementModel.Types;

    }
}