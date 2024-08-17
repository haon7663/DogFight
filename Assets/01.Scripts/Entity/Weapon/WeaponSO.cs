using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    OneHand,
    TwoHands,
    ShortSword
}
[CreateAssetMenu(menuName = "SO/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    public WeaponType weaponType;
    public int damage;
}
