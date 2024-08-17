using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    private List<ParallaxBackground> _backgrounds;
    [SerializeField]
    private Button _startBtn, _exitBtn;
    [SerializeField]
    private RectTransform _panel, _titleText, _creatorText;

    private void Awake()
    {
        StartCoroutine(TitleSceneCoroutine());
        _startBtn.onClick.AddListener(HandleStartBtnClick);
        _exitBtn.onClick.AddListener(() => Application.Quit());
    }

    private void HandleStartBtnClick()
    {
        SceneManager.LoadScene(SceneNames.InGameScene);
    }

    private IEnumerator TitleSceneCoroutine()
    {
        transform.position = new Vector3(0, 20, 0);
        transform.DOMoveY(-0.5f, 3f).SetEase(Ease.InOutQuint);
        yield return new WaitForSeconds(3.5f);

        _panel.DOAnchorPosX(0, 0.8f).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds(1.5f);
        _titleText.DOAnchorPosX(-101, 0.8f).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds(0.4f);
        (_startBtn.transform as RectTransform).DOAnchorPosX(0, 0.8f).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds(0.4f);
        (_exitBtn.transform as RectTransform).DOAnchorPosX(0, 0.8f).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds(1.5f);
        _creatorText.DOAnchorPosY(-985, 1f).SetEase(Ease.OutQuad);

    }

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * 0.2f;
    }
}
