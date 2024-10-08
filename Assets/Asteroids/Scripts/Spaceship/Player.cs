using System.Collections.Generic;
using Asteroids.Spaceship;
using EventBusSystem;
using UnityEngine;

namespace Asteroids
{
    public class Player : MonoBehaviour
    {
        private readonly List<KeyCode> _pressedKeys = new();
        
        [SerializeField] private SpaceshipEngine _spaceshipEngine;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _pressedKeys.Add(KeyCode.UpArrow);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _pressedKeys.Add(KeyCode.DownArrow);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _pressedKeys.Add(KeyCode.LeftArrow);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _pressedKeys.Add(KeyCode.RightArrow);
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                _pressedKeys.Remove(KeyCode.UpArrow);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                _pressedKeys.Remove(KeyCode.DownArrow);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _pressedKeys.Remove(KeyCode.LeftArrow);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                _pressedKeys.Remove(KeyCode.RightArrow);
            }

            // var velocity = _spaceshipEngine.Velocity;
            bool isVertical = false;
            bool isHorizontal = false;
            
            for (int i = _pressedKeys.Count - 1; i >= 0; i--)
            {
                if (_pressedKeys[i] == KeyCode.UpArrow && isVertical == false)
                {
                    _spaceshipEngine.MoveUp();
                    isVertical = true;
                }
                if (_pressedKeys[i] == KeyCode.DownArrow && isVertical == false)
                {
                    _spaceshipEngine.MoveDown();
                    isVertical = true;
                }
                if (_pressedKeys[i] == KeyCode.LeftArrow && isHorizontal == false)
                {
                    _spaceshipEngine.MoveLeft();
                    isHorizontal = true;
                }
                if (_pressedKeys[i] == KeyCode.RightArrow && isHorizontal == false)
                {
                    _spaceshipEngine.MoveRight();
                    isHorizontal = true;
                }
            }

            if (isVertical == false)
            {
                _spaceshipEngine.StopVerticalMoving();
            }

            if (isHorizontal == false)
            {
                _spaceshipEngine.StopHorizontalMoving();
            }
        }

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