using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHudController : MonoBehaviour
{
    [SerializeField] private DamageHud damageHudPrefab;
    [SerializeField] private Transform canvas;
    [SerializeField] private Vector3 offset;

    public void Generate(GameObject obj, int damage)
    {
        var hud = Instantiate(damageHudPrefab, obj.transform.position + offset, Quaternion.identity, canvas);
        hud.Initialize(damage);
    }
}
