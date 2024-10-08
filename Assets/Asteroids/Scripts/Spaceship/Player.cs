using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

namespace Asteroids
{
    public class Player : MonoBehaviour
    {
        private readonly List<KeyCode> _pressedKeys = new();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Asteroid asteroid) == true)
            {
                EventBus.RaiseEvent<IEventHandler>(handler => handler.HandleDestroySpaceship());
                Destroy(gameObject);
            }
        }
    }
}