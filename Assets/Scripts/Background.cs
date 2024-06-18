using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _bg1;
    [SerializeField]
    private SpriteRenderer _bg2;
    [SerializeField]
    private float _speed;

    private void Update()
    {
        var position = _bg1.transform.position;
        _bg1.transform.position = new Vector3(position.x, position.y - _speed, position.z);
        
        var position2 = _bg2.transform.position;
        _bg2.transform.position = new Vector3(position2.x, position2.y - _speed, position2.z);

        if (position.y < -18)
        {
            _bg1.transform.position = new Vector3(position.x, position.y + _bg1.size.x * 3, position.z);
        }
        
        if (position2.y < -18)
        {
            _bg2.transform.position = new Vector3(position2.x, position2.y + _bg2.size.x * 3, position2.z);
        }
    }
}