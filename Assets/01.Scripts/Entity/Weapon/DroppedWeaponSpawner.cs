using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DroppedWeaponSpawner : MonoBehaviour
{
    [SerializeField]
    private DroppedWeapon _weaponPrefab;
    [SerializeField]
    private List<WeaponSO> _dropWeaponList;

    private List<DroppedWeapon> _droppedWeaponList = new List<DroppedWeapon>();

    [SerializeField]
    private int _maximumSpawnCount = 15;
    [SerializeField]
    private float _spawnDelayTime = 3f;
    private float _spawnDelayTimer = 0f;

    private void Start()
    {
        for (int i = 0; i < 8; i++)
            SpawnWeapon();
    }

    private void Update()
    {
        _spawnDelayTimer += Time.deltaTime;
        if(_spawnDelayTimer > _spawnDelayTime)
        {
            _droppedWeaponList = _droppedWeaponList.Where(x => x != null).ToList();
            SpawnWeapon();
            _spawnDelayTimer = 0;
        }
    }

    private void SpawnWeapon()
    {
        if (_droppedWeaponList.Count > _maximumSpawnCount) return;
        WeaponSO spawnWeapon = _dropWeaponList[Random.Range(0, _dropWeaponList.Count)];
        DroppedWeapon weapon = Instantiate(_weaponPrefab, new Vector2(Random.Range(-85f, 75f), spawnWeapon.name == "Stick" ? 8 : -1), Quaternion.identity);
        weapon.Initialize(spawnWeapon);
        _droppedWeaponList.Add(weapon);
    }
}
