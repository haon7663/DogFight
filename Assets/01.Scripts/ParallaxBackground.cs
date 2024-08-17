using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    Vector2 _ratio;

    private Transform _mainCamTrm;
    private Vector2 _initPosition;
    private Vector2 _spriteSize;
    private Vector2 _camInitPosition;

    private void Awake()
    {
        _mainCamTrm = Camera.main.transform;
        _camInitPosition = _mainCamTrm.position;
        _initPosition = transform.position;
        _spriteSize = GetComponentInChildren<SpriteRenderer>().bounds.size;
    }

    private void LateUpdate()
    {
        MoveToCameraPosition();
    }

    private void MoveToCameraPosition()
    {
        Vector2 cameraDelta = (Vector2)_mainCamTrm.position - _camInitPosition;

        Vector2 moveOffset = new Vector2(cameraDelta.x * _ratio.x, 0);
        transform.position = _initPosition + moveOffset;

        Vector2 deltaFromCam = _mainCamTrm.position - transform.position;

        if (deltaFromCam.x > _spriteSize.x)
            _initPosition.x += _spriteSize.x;
        else if (deltaFromCam.x < -_spriteSize.x)
            _initPosition.x -= _spriteSize.x;

    }
}