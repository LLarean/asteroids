using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Spaceship
{
    public class InputMoveHandler : MonoBehaviour
    {
        private readonly List<KeyCode> _pressedKeys = new();

        [SerializeField] private SpaceshipEngine _spaceshipEngine;
        
        private void Update()
        {
            AddKey();
            RemoveKey();
            SetMovingDirection();
        }

        private void AddKey()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) == true)
            {
                _pressedKeys.Add(KeyCode.UpArrow);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) == true)
            {
                _pressedKeys.Add(KeyCode.DownArrow);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
            {
                _pressedKeys.Add(KeyCode.LeftArrow);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) == true)
            {
                _pressedKeys.Add(KeyCode.RightArrow);
            }
        }

        private void RemoveKey()
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) == true)
            {
                _pressedKeys.Remove(KeyCode.UpArrow);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) == true)
            {
                _pressedKeys.Remove(KeyCode.DownArrow);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) == true)
            {
                _pressedKeys.Remove(KeyCode.LeftArrow);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) == true)
            {
                _pressedKeys.Remove(KeyCode.RightArrow);
            }
        }
        
        private void SetMovingDirection()
        {
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
    }
}