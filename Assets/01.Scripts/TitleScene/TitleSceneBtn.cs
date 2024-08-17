using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleSceneBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI _text;
    private Tween _colorTween;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_colorTween != null && _colorTween.IsActive())
            _colorTween.Kill();
        _colorTween = _text.DOColor(Color.red, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_colorTween != null && _colorTween.IsActive())
            _colorTween.Kill();
        _colorTween = _text.DOColor(Color.white, 0.3f);
    }

}
