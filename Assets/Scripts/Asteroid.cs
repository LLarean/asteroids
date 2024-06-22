using System;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _speed = 1;
    
    public event Action OnDestroyed;

    private void Start()
    {
        _rigidbody2D.velocity = new Vector2(0,-_speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnDestroyed?.Invoke();
        Destroy(gameObject);
    }
}