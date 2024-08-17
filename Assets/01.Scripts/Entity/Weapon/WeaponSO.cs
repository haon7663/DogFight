using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum ThrowingType
{
    Linear,
    Rotation,
}

[CreateAssetMenu(menuName = "SO/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    
    [Header("기본")]
    public Sprite grabSprite;
    public RuntimeAnimatorController animatorController;
    public int swingDamage;
    public int durability;
    public SquareAttackRange[] attackRange;
    
    [Header("투척")]
    public Sprite throwSprite;
    public ThrowingType throwingType;
}
