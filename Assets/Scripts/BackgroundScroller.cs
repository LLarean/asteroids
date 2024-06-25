using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField]
    private float _scrollingSpeed;
    [SerializeField]
    private List<SpriteRenderer> _backgrounds;

    private Coroutine _coroutine;
    private bool _canScroll;

    public void StartScrolling()
    {
        _canScroll = true;
        _coroutine = StartCoroutine(Scrolling());
    }

    public void StopScrolling()
    {
        _canScroll = false;

        if (_coroutine != null)
        {
            StopCoroutine(Scrolling());
        }
    }
    
    private void Start() => StartScrolling();

    private void OnDestroy() => StopScrolling();

    private IEnumerator Scrolling()
    {
        while (_canScroll == true)
        {
            ScrollBackgrounds();
            MoveToStartPosition();
            yield return new WaitForFixedUpdate();
        }
    }

    private void ScrollBackgrounds()
    {
        foreach (var background in _backgrounds)
        {
            var position = background.transform.position;
            background.transform.position = new Vector3(position.x, position.y - _scrollingSpeed, position.z);
        }
    }

    private void MoveToStartPosition()
    {
        foreach (var background in _backgrounds)
        {
            var position = background.transform.position;
            
            if (position.y < -background.size.x * 1.5)
            {
                background.transform.position = new Vector3(position.x, position.y + background.size.x * 3, position.z);
            }
        }
    }
}