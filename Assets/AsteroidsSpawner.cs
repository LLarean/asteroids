using System.Collections;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField]
    private Asteroid _asteroid;
    [SerializeField]
    private float _spawnInterval = 4;

    private bool _canSpawn;

    private void Start()
    {
        _canSpawn = true;
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while(_canSpawn == true)
        {
            Instantiate(_asteroid, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

}