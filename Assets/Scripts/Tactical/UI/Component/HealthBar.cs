using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    [SerializeField] private TMP_Text hpLabel;
    
    private GameObject _obj;

    public void Initialize(GameObject obj)
    {
        _obj = obj;
    }
    
    private void HpChange()
    {
        /*var health = _obj.GetComponent<Health>();
        
        var fill = (float)health.curHp / health.maxHp;
        hpSlider.value = fill;
        hpLabel.text = health.curHp.ToString();*/
    }
}
