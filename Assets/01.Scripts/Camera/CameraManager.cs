using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField]
    private CinemachineVirtualCamera _mainCam;
    private CinemachineBasicMultiChannelPerlin _perlin;
    private Tween _shakeTween;

    private void Awake()
    {
        _perlin = _mainCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public void ShakeCamera(float power, float duration)
    {
        _perlin.m_AmplitudeGain = power;
        if (_shakeTween != null && _shakeTween.IsActive())
            _shakeTween.Kill();
        _shakeTween = DOTween.To(() => _perlin.m_AmplitudeGain, v => _perlin.m_AmplitudeGain = v, 0, duration).OnComplete(() => Camera.main.transform.rotation = Quaternion.identity);
    }

}
