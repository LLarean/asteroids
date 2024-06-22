using UnityEngine;

public class Missile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Spaceship spaceship) == false)
        {
            Destroy(gameObject);
        }
    }
}