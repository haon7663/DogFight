using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;

[Serializable]
public struct SquareAttackRange
{
    public Vector2 center;
    public Rect range;
}

public class SquareDamageCaster : MonoBehaviour
{
    [SerializeField]
    private Entity _owner;
    [SerializeField]
    private int _maxColliderCount;
    private Collider2D[] _colliders;
    [SerializeField]
    private LayerMask _targetLayer;

    private void Awake()
    {
        _colliders = new Collider2D[_maxColliderCount];
    }

    public bool DamageCast(SquareAttackRange range, out List<Collider2D> targets)
    {
        int count = Physics2D.OverlapBoxNonAlloc((Vector2)transform.position + range.center * (_owner.IsFacingRight ? Vector2.right : Vector2.left), range.range.size, 0, _colliders, _targetLayer);
        targets = null;
        if (count <= 0) return false;
        for (int i = 0; i < count; i++)
        {
            if (_colliders[i].TryGetComponent(out IDamageable health))
            {
                //health.GetDamage(_owner.Stat.damage);
                health.GetDamage(5);
            }
        }
        targets = _colliders.ToList().Where(x => x != null).ToList();
        return true;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        //SquareAttackRange[] range = _owner..attackRange;
        //if (range.Length <= 0) return;
        //for (int i = 0; i < range.Length; i++)
        //{
        //    if (i == range.Length - 1)
        //        Gizmos.color = Color.blue;
        //    else
        //        Gizmos.color = Color.red;
        //    if (_owner == null)
        //        Gizmos.DrawWireCube((Vector2)transform.position + range[i].center, range[i].range.size);
        //    else
        //        Gizmos.DrawWireCube((Vector2)transform.position + range[i].center * (_owner.IsFacingRight ? Vector2.right : Vector2.left), range[i].range.size);
        //}
    }
#endif
}
