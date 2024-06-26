using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField]
    private Laser _laser;
    [SerializeField]
    private Transform _laserSpawnPosition;

    private bool _canShoot;
    private List<Laser> _lasers = new();
    
    private void Start()
    {
        _canShoot = true;
        StartCoroutine(Pew());
    }

    private IEnumerator Pew()
    {
        while(_canShoot == true)
        {
            LaunchLaser();
            yield return new WaitForSeconds(Config.LaserAttackSpeed);
        }
    }
    
    private void LaunchLaser()
    {
        var laser = GetLaser();
        
        laser.transform.position = _laserSpawnPosition.transform.position;
        laser.gameObject.SetActive(true);
        laser.StartMoving();
    }
    
    private Laser GetLaser()
    {
        foreach (var item in _lasers.Where(item => item.gameObject.activeSelf == false))
        {
            return item;
        }

        var laser = Instantiate(_laser);
        laser.transform.SetParent(transform);
        _lasers.Add(laser);

        return laser;
    }
}