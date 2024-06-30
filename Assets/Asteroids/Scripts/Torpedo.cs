using UnityEngine;

public class Torpedo : Missile
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    private float _speed = Config.TorpedoMissileSpeed;

    public void StartMoving()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x,_speed);
    }
}
