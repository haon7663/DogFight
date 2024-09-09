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
    
    private readonly Vector3 _offset = new Vector3(0, 1.55f);

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
        if (!hpSlider)
            return;
        
        var health = _obj.GetComponent<Health>();
        
        var fill = (float)health.curHp / health.maxHp;
        hpSlider.value = fill;
        
        hpSlider.gameObject.SetActive(true);
        
        if (health.curHp <= 0)
            Destroy(gameObject);
    }

    private void LateUpdate()
    {
        if (!_obj)
            return;
        transform.position = _obj.transform.position + _offset;
    }
}
