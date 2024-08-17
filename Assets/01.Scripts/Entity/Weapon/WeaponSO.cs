using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum WeaponType
{
    OneHand,
    TwoHands,
    ShortSword
}

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
    public int swingDamage;
    public WeaponType weaponType;
    public SquareAttackRange[] attackRange;
    
    [Header("투척")]
    public Sprite throwSprite;
    public int throwDamage;
    public ThrowingType throwingType;
}
