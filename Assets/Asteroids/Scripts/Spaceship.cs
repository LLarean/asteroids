using System;
using EventBusSystem;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Asteroid asteroid) == true)
        {
            EventBus.RaiseEvent<IEventHandler>(handler => handler.HandleDestroySpaceship());
            Destroy(gameObject);
        }
    }
}