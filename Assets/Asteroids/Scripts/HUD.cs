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
        _health.text = $"HP: {_healthValue}";
        _experience.text = $"EXP: {_experienceValue}";
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
        _health.text = $"HP: {_healthValue}";
    }

    public void HandleExperienceChange()
    {
        _experienceValue++;
        _experience.text = $"EXP: {_experienceValue}";

        if (_experienceValue / Config.ExpForBonus == 1)
        {
            _experienceValue = 0;
            EventBus.RaiseEvent<IEventHandler>(handler => handler.HandleSelectBonusSpaceship());
        }
    }

    public void HandleBonusAdd()
    {
    }
}