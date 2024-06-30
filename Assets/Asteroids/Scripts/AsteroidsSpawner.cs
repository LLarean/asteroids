using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField]
    private Asteroid _asteroid;
    [SerializeField]
    [MinMaxSlider(0.0f, 10.0f)]
    private Vector2 _spawInterval;

    private List<Asteroid> _asteroids = new();
    private Coroutine _coroutine;
    private bool _canSpawn;
    private float _minPositionX;
    private float _maxPositionX;

    public void StartSpawn()
    {
        _canSpawn = true;
        _coroutine = StartCoroutine(Spawning());
    }

    public void StopSpawn()
    {
        _canSpawn = false;

        if (_coroutine != null)
        {
            StopCoroutine(Spawning());
        }
    }

    private void Start()
    {
        _minPositionX = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
        _maxPositionX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        
        StartSpawn();
    }
    
    private IEnumerator Spawning()
    {
        while(_canSpawn == true)
        {
            LaunchAsteroid();

            var spawnInterval = Random.Range(_spawInterval.x, _spawInterval.y);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void LaunchAsteroid()
    {
        var position = new Vector2(Random.Range(_minPositionX, _maxPositionX), transform.position.y);
        var asteroid = GetAsteroid();
        
        asteroid.transform.position = position;
        asteroid.gameObject.SetActive(true);
        asteroid.StartMoving();
    }

    private Asteroid GetAsteroid()
    {
        foreach (var item in _asteroids.Where(item => item.gameObject.activeSelf == false))
        {
            return item;
        }

        var asteroid = Instantiate(_asteroid);
        asteroid.transform.SetParent(transform);
        _asteroids.Add(asteroid);

        return asteroid;
    }
}