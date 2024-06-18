using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _speed = 4;

    private Transform _transform;
    private float _minPositionX;
    private float _maxPositionX;
    private float _minPositionY;
    private float _maxPositionY;

    private void Start()
    {
        _transform = transform;
        
        _minPositionX = _camera.ScreenToWorldPoint(new Vector2(0, 0)).x;
        _maxPositionX = _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        _minPositionY = _camera.ScreenToWorldPoint(new Vector2(0, 0)).y;
        _maxPositionY = _camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
    }

    private void Update()
    {
        var velocity = _rigidbody2D.velocity;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _rigidbody2D.velocity = new Vector2(velocity.x, _speed);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _rigidbody2D.velocity = new Vector2(velocity.x, -_speed);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _rigidbody2D.velocity = new Vector2(-_speed, velocity.y);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _rigidbody2D.velocity = new Vector2(_speed, velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _rigidbody2D.velocity = new Vector2(velocity.x, 0);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            _rigidbody2D.velocity = new Vector2(velocity.x, 0);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _rigidbody2D.velocity = new Vector2(0, velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _rigidbody2D.velocity = new Vector2(0, velocity.y);
        }

        RestrictMovement();
    }
    
    private void RestrictMovement()
    {
        Vector3 screenPoint = _camera.WorldToScreenPoint(_transform.position);

        if (screenPoint.x < _minPositionX)
        {
            _transform.position = new Vector2(_minPositionX, _transform.position.y);
        }
        else if (screenPoint.x > Screen.width)
        {
            _transform.position = new Vector2(_maxPositionX , _transform.position.y);
        }
        else if (screenPoint.y < _minPositionY)
        {
            _transform.position = new Vector2(_transform.position.x, _minPositionY);
        }
        else if (screenPoint.y > Screen.height)
        {
            _transform.position = new Vector2(_transform.position.x, _maxPositionY);
        }
    }
}