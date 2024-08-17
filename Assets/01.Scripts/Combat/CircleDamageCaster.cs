using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CircleAttackRange
{
    public Vector2 center;
    public float radius;
}

public class CircleDamageCaster : DamageCaster
{
    [SerializeField]
    private int _maxColliderCount;
    private Collider2D[] _colliders;


    [SerializeField]
    private CircleAttackRange[] _attackRange;

    private void Awake()
    {
        _colliders = new Collider2D[_maxColliderCount];
    }

    public override void DamageCast(int combo)
    {
        CircleAttackRange range = _attackRange[combo];
        int count = Physics2D.OverlapCircleNonAlloc((Vector2)transform.position + range.center * (_owner.IsFacingRight ? Vector2.left : Vector2.right), range.radius, _colliders, _targetLayer);

        if (count <= 0) return;
        for (int i = 0; i < count; i++)
        {
            if (_colliders[i].TryGetComponent(out IDamageable health))
            {
                //health.GetDamage(_owner.Stat.damage);
                health.GetDamage(2);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        //if (_owner == null) return;
        if (_attackRange.Length <= 0) return;
        for (int i = 0; i < _attackRange.Length; i++)
        {
            if (i == _attackRange.Length - 1)
                Gizmos.color = Color.blue;
            else
                Gizmos.color = Color.red;
            if (_owner == null)
                Gizmos.DrawWireSphere((Vector2)transform.position + _attackRange[i].center, _attackRange[i].radius);
            else
                Gizmos.DrawWireSphere((Vector2)transform.position + _attackRange[i].center * (_owner.IsFacingRight ? Vector2.left : Vector2.right), _attackRange[i].radius);
        }
    }
#endif
}
