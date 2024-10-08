using Asteroids.Scripts.Project;
using EventBusSystem;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    private float _speed = Config.AsteroidSpeed;
    
    public void StartMoving()
    {
        _rigidbody2D.velocity = new Vector2(0,-_speed);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        EventBus.RaiseEvent<IGameHandler>(handler => handler.HandleExperienceChange());
        _rigidbody2D.velocity = Vector2.zero;
        
        AudioPlayer.Instance.PlayExplosion();
        gameObject.SetActive(false);
    }
}