using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathWindow : MonoBehaviour
{
    [SerializeField] private Image backGround;
    [SerializeField] private TMP_Text label;
    [SerializeField] private TMP_Text countLabel;
    [SerializeField] private TMP_Text retryLabel;
    
    public void Show()
    {
        countLabel.text = $"처치한 적의 수: {BattleController.Inst.killCount}";
        
        var sequence = DOTween.Sequence().SetUpdate(true);;
        sequence.Append(backGround.DOFade(0.8f, 0.5f));
        sequence.Append(label.DOFade(1, 0.5f));
        sequence.Append(countLabel.DOFade(1, 0.5f));
        sequence.AppendInterval(1f);
        sequence.Append(retryLabel.DOFade(1, 0.5f));
    }
}
