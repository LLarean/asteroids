using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _speed = 1;
    
    private Transform _transform;
    private float _minPositionY;
    private float _maxPositionY;

    private void Start()
    {
        _transform = transform;
        
        _minPositionY = _camera.ScreenToWorldPoint(new Vector2(0, 0)).y;
        _maxPositionY = _camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        
        _rigidbody2D.velocity = new Vector2(0,-_speed);
    }
    
    private void Update()
    {
        RestrictMovement();
    }

    private void RestrictMovement()
    {
        Vector3 screenPoint = _camera.WorldToScreenPoint(_transform.position);

        if (screenPoint.y < _minPositionY)
        {
            _transform.position = new Vector2(_transform.position.x, _maxPositionY + 1);
        }
    }
}
