using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _speed = 1;
    
    public void StartMoving()
    {
        _rigidbody2D.velocity = new Vector2(0,-_speed);
    }
    
    private void Start()
    {
        _rigidbody2D.velocity = new Vector2(0,-_speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _rigidbody2D.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}