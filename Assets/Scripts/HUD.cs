using EventBusSystem;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour, IGameHandler
{
    [SerializeField]
    private TMP_Text _health;
    [SerializeField]
    private TMP_Text _experience;

    private int _healthValue = 3;
    private int _experienceValue;

    private void Start()
    {
        _health.text = _healthValue.ToString();
        _experience.text = _experienceValue.ToString();
    }

    private void OnEnable()
    {
        EventBus.Subscribe(this);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }
    
    public void HandleHealthChange()
    {
        _healthValue--;
        _health.text = _healthValue.ToString();
    }

    public void HandleExperienceChange()
    {
        _experienceValue++;
        _experience.text = _experienceValue.ToString();
    }
}