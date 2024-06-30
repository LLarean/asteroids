using EventBusSystem;
using UnityEngine;

public class EventHandler : MonoBehaviour, IEventHandler
{
    [SerializeField]
    private GameObject _end;
    [SerializeField]
    private GameObject _choosingBonus;
    
    public void HandleDestroySpaceship()
    {
        _end.gameObject.SetActive(true);
    }

    public void HandleSelectBonusSpaceship()
    {
        Time.timeScale = 0;
        _choosingBonus.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        EventBus.Subscribe(this);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }
}