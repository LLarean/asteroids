using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusCard : MonoBehaviour
{
    [SerializeField] private Button _selfButton;
    [SerializeField] private TMP_Text _label;

    public event Action OnButtonClick;

    private void Start()
    {
        _selfButton.onClick.AddListener(AddBonus);
    }

    private void AddBonus()
    {
        OnButtonClick?.Invoke();
    }
}