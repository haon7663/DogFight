using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ThrowingWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed;

    private WeaponSO _weaponSO;
    public void Initialize(WeaponSO weaponSO, Vector2 dir)
    {
        _weaponSO = weaponSO;
        spriteRenderer.sprite = weaponSO.throwSprite;

        Fire(dir);
    }
    
    private void Fire(Vector2 dir)
    {
        spriteRenderer.flipX = dir.x < 0;
        rigid.velocity = dir * speed;
    }

    private void Update()
    {
        if (_weaponSO.throwingType == ThrowingType.Linear)
            return;
        spriteRenderer.transform.Rotate(new Vector3(0, 0, 360) * Time.deltaTime);
    }
}
