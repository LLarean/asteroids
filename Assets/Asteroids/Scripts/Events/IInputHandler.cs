using EventBusSystem;
using UnityEngine;

namespace Asteroids.Events
{
    public interface IInputHandler : IGlobalSubscriber
    {
        void KeyUp(KeyCode keyCode);
        void KeyDown(KeyCode keyCode);
    }
}