using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedWeapon : MonoBehaviour, IInteractable
{
    private WeaponSO _weaponSO;

    private SpriteRenderer _spriteRenderer;

    public void Initialize(WeaponSO weaponSO)
    {
        _weaponSO = weaponSO;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _weaponSO.throwSprite;
    }

    public void Interact(Player interacted)
    {
        interacted.WeaponCompo.SetWeapon(_weaponSO);
        Destroy(gameObject);
    }

    public GameObject GameObject { get; set; }
}
