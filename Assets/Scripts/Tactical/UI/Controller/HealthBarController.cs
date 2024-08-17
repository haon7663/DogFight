using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private HealthBar healthBarPrefab;
    [SerializeField] private Transform canvas;

    public void ConnectPanel(GameObject obj)
    {
        /*if (!obj.TryGetComponent<Health>(out var health))
            return;

        var previewStat = Instantiate(statBarPrefab, canvas);
        previewStat.Init(obj);*/
    }
}
