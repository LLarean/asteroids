using EventBusSystem;
using UnityEngine;

public class EventHandler : MonoBehaviour, IEventHandler
{
    [SerializeField]
    private GameObject _end;
    
    public void HandleDestroySpaceship()
    {
        _end.gameObject.SetActive(true);
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