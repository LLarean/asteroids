using UnityEngine;

namespace Asteroids.Spaceship
{
    public class RestrictMovement : MonoBehaviour
    {
        private Camera _camera;

        private float _minPositionX;
        private float _maxPositionX;
        private float _minPositionY;
        private float _maxPositionY;

        private void Update()
        {
            if(_camera == null) return;

            SetPosition();
        }

        private void Awake()
        {
            _camera = Camera.main;
        
            if(_camera == null) return;
            
            _minPositionX = _camera.ScreenToWorldPoint(new Vector2(0, 0)).x;
            _maxPositionX = _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
            _minPositionY = _camera.ScreenToWorldPoint(new Vector2(0, 0)).y;
            _maxPositionY = _camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        }

        private void SetPosition()
        {
            Vector3 screenPoint = _camera.WorldToScreenPoint(transform.position);
        
            if (screenPoint.x < _minPositionX)
            {
                transform.position = new Vector2(_minPositionX, transform.position.y);
            }
            else if (screenPoint.x > Screen.width)
            {
                transform.position = new Vector2(_maxPositionX , transform.position.y);
            }
            else if (screenPoint.y < _minPositionY)
            {
                transform.position = new Vector2(transform.position.x, _minPositionY);
            }
            else if (screenPoint.y > Screen.height)
            {
                transform.position = new Vector2(transform.position.x, _maxPositionY);
            }
        }
    }
}
