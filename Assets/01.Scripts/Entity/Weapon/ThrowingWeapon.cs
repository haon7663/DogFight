using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ThrowingWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public void Initialize(WeaponSO weaponSO)
    {
        spriteRenderer.sprite = weaponSO.throwSprite;
    }
    
    public void Fire(Vector2 dir)
    {
        rigid.velocity = dir;
    }
}
