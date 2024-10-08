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
        gameObject.SetActive(false);
        _rigidbody2D.velocity = Vector2.zero;

        if (other.TryGetComponent(out Laser laser) == false) return;
        
        EventBus.RaiseEvent<IGameHandler>(handler => handler.HandleExperienceChange());
        AudioPlayer.Instance.PlayExplosion();
    }
}