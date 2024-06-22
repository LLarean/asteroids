using UnityEngine;

public class Laser : Missile
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _speed;

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _speed);
    }

    public void SetVelocity()
    {
    }
}
