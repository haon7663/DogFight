using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropItems : MonoBehaviour
{
    public Enemy EnemyCompo { get; private set; }
    public DroppedWeapon droppedWeaponPrefab;

    private void Start()
    {
        EnemyCompo = GetComponent<Enemy>();
    }

    public void SummonItem()
    {
        var maxCount = EnemyCompo.Data.dropItems.Length;
        var weapon = Instantiate(droppedWeaponPrefab, transform.position, Quaternion.identity);
        weapon.Initialize(EnemyCompo.Data.dropItems[Random.Range(0, maxCount)]);
        if (weapon.TryGetComponent<Rigidbody2D>(out var rigid))
        {
            var randomCircle = Random.insideUnitCircle.normalized;
            rigid.AddForce(new Vector2(randomCircle.x, Mathf.Abs(randomCircle.y)) * 9, ForceMode2D.Impulse);
        }
    }
}
