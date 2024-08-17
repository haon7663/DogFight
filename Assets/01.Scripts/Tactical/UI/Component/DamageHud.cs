using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamageHud : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    private void Start()
    {
        Initialize(5);
    }

    public void Initialize(int value)
    {
        label.text = value.ToString();

        var size = label.fontSize;
        var sequence = DOTween.Sequence();
        sequence.Append(DOVirtual.Float(size, size * 0.2f, 0.4f, x => label.fontSize = x).SetEase(Ease.InCubic)).OnComplete(() => Destroy(gameObject));
        sequence.Insert(0.2f, label.DOFade(0, 0.199f));
    }
}
