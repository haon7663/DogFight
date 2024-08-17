using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    private GameObject _obj;
    
    private readonly Vector3 _offset = new Vector3(0, 0.6f);

    public void Initialize(GameObject obj)
    {
        _obj = obj;

        if (obj.TryGetComponent<Health>(out var health))
        {
            health.OnHpChanged += ChangeUI;
        }
    }
    
    [ContextMenu("Change UI")]
    private void ChangeUI()
    {
        var health = _obj.GetComponent<Health>();
        
        var fill = health.curHp / health.maxHp;
        hpSlider.value = fill;
        
        hpSlider.gameObject.SetActive(true);
    }

    private void LateUpdate()
    {
        transform.position = _obj.transform.position + _offset;
    }
}
