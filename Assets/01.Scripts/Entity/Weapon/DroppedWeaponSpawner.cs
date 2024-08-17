using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedWeaponSpawner : MonoBehaviour
{
    [SerializeField]
    private DroppedWeapon _weaponPrefab;
    [SerializeField]
    private List<WeaponSO> _dropWeaponList;

    private void Awake()
    {
        DroppedWeapon weapon = Instantiate(_weaponPrefab, transform.position, Quaternion.identity);
        weapon.Initialize(_dropWeaponList[Random.Range(0, _dropWeaponList.Count)]);
    }
}
