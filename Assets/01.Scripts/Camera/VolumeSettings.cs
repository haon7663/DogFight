using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class VolumeSettings : MonoBehaviour
{
private Volume _volume;

    private float _vignetteIntensity;
    private float _vignetteSmoothness;
    private Color _vignetteColor;

    private void Awake()
    {
        _volume = GetComponent<Volume>();
        SetDefaultValues();
    }

    private void SetDefaultValues()
    {
        if (_volume.profile.TryGet(out Vignette vignette))
        {
            _vignetteIntensity = vignette.intensity.value;
            _vignetteSmoothness = vignette.smoothness.value;
            _vignetteColor = vignette.color.value;
        }
    }

    public void SetVolume()
    {
        if (_volume.profile.TryGet(out Vignette vignette))
        {
            var sequence = DOTween.Sequence();
            sequence.AppendCallback(() =>
            {
                DOVirtual.Float(_vignetteIntensity, 0.6f, 0.5f, value => vignette.intensity.value = value);
                DOVirtual.Float(_vignetteSmoothness, 0.6f, 0.5f, value => vignette.smoothness.value = value);
                DOVirtual.Color(_vignetteColor, Color.red, 0.5f, value => vignette.color.value = value);
            });
            sequence.AppendInterval(0.5f);
            sequence.AppendCallback(() =>
            {
                DOVirtual.Float(0.6f, _vignetteIntensity, 0.2f, value => vignette.intensity.value = value);
                DOVirtual.Float(0.6f, _vignetteSmoothness, 0.2f, value => vignette.smoothness.value = value);
                DOVirtual.Color(Color.red, _vignetteColor, 0.2f, value => vignette.color.value = value);
            });
        } 
    }
}
