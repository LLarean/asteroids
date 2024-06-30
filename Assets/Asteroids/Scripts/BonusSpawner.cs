using System.Collections;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform _bonus;
    
    private float _minPositionX;
    private float _maxPositionX;
    private float _minPositionY;
    private float _maxPositionY;
    
    private bool _canSpawn;
    private Coroutine _coroutine;

    private void Start()
    {
        var camera = Camera.main;
        
        _minPositionX = camera.ScreenToWorldPoint(new Vector2(0, 0)).x;
        _maxPositionX = camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        _minPositionY = camera.ScreenToWorldPoint(new Vector2(0, 0)).y;
        _maxPositionY = camera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        
        StartSpawn();
    }
    
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

    private IEnumerator Spawning()
    {
        while(_canSpawn == true)
        {
            LaunchAsteroid();

            yield return new WaitForSeconds(Config.BonusSpawnTime);
        }
    }

    private void LaunchAsteroid()
    {
        var position = new Vector2(Random.Range(_minPositionX, _maxPositionX), transform.position.y);
        // var asteroid = GetAsteroid();
        
        // asteroid.transform.position = position;
        // asteroid.gameObject.SetActive(true);
        // asteroid.StartMoving();
    }

    // private Asteroid GetAsteroid()
    // {
    //     foreach (var item in _asteroids.Where(item => item.gameObject.activeSelf == false))
    //     {
    //         return item;
    //     }
    //
    //     var asteroid = Instantiate(_asteroid);
    //     asteroid.transform.SetParent(transform);
    //     _asteroids.Add(asteroid);
    //
    //     return asteroid;
    // }
}