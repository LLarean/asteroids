using Asteroids;
using Asteroids.Scripts;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player spaceship) == false)
        {
            gameObject.SetActive(false);
        }
    }
}