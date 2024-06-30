using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TorpedoTubes : MonoBehaviour
{
    [SerializeField]
    private Torpedo _torpedo;
    [SerializeField]
    private List<Transform> _torpedoSpawns;

    private bool _canShoot;
    private List<Torpedo> _torpedoes = new();
    
    private void Start()
    {
        _canShoot = true;
        StartCoroutine(Pew());
    }

    private IEnumerator Pew()
    {
        while(_canShoot == true)
        {
            LaunchTorpedo();
            yield return new WaitForSeconds(Config.LaserAttackSpeed);
        }
    }
    
    private void LaunchTorpedo()
    {
        for (int i = 0; i < Config.LaserGunLevel; i++)
        {
            var torpedo = GetTorpedo();
        
            torpedo.transform.position = _torpedoSpawns[i].transform.position;
            torpedo.gameObject.SetActive(true);
            torpedo.StartMoving();
        }
    }
    
    private Torpedo GetTorpedo()
    {
        foreach (var item in _torpedoes.Where(item => item.gameObject.activeSelf == false))
        {
            return item;
        }

        var torpedo = Instantiate(_torpedo);
        torpedo.transform.SetParent(transform);
        _torpedoes.Add(torpedo);

        return torpedo;
    }
}
