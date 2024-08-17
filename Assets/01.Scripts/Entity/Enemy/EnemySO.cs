using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EnemySO", fileName = "EnemySO")]
public class EnemySO : ScriptableObject
{
    public RuntimeAnimatorController animatorController;
    public int maxHp;
    public float moveSpeed;
    public int damage;
    public SquareAttackRange[] attackRange;
    public Sprite weapon;

    public WeaponSO[] dropItems;
}
