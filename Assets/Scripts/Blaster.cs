using System.Collections;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField]
    private Laser _laser;

    private bool _canShoot;
    
    private void Start()
    {
        _canShoot = true;
        StartCoroutine(Pew());
    }

    private IEnumerator Pew()
    {
        while(_canShoot == true)
        {
            Instantiate(_laser, transform.position, Quaternion.identity);
            _laser.SetVelocity();
            yield return new WaitForSeconds(1f);
        }
    }
}