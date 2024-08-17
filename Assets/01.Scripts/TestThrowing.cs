using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestThrowing : MonoBehaviour
{
    [SerializeField] private ThrowingWeapon throwingWeapon;
    [SerializeField] private WeaponSO weaponSO;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var weapon = Instantiate(throwingWeapon);
            weapon.Initialize(weaponSO, Vector2.right);
        }
    }
}
