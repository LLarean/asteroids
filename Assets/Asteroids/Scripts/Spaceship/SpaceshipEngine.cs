using UnityEngine;

namespace Asteroids.Spaceship
{
    public class SpaceshipEngine : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public void MoveUp()
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Config.SpaceshipMoveSpeed);
        }

        public void MoveDown()
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, -Config.SpaceshipMoveSpeed);
        }

        public void MoveLeft()
        {
            _rigidbody2D.velocity = new Vector2(-Config.SpaceshipMoveSpeed, _rigidbody2D.velocity.y);
        }

        public void MoveRight()
        {
            _rigidbody2D.velocity = new Vector2(Config.SpaceshipMoveSpeed, _rigidbody2D.velocity.y);
        }

        public void StopVerticalMoving()
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        }

        public void StopHorizontalMoving()
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }
    }
}