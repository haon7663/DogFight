using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SquareAttackRange
{
    public Vector2 center;
    public Rect range;
}

public class SqaureDamageCaster : DamageCaster
{
    [SerializeField]
    private int _maxColliderCount;
    private Collider2D[] _colliders;

    public SquareAttackRange[] _attackRange;

    private void Awake()
    {
        _colliders = new Collider2D[_maxColliderCount];
    }

    public override void DamageCast(int combo)
    {
        SquareAttackRange range = _attackRange[combo];
        int count = Physics2D.OverlapBoxNonAlloc((Vector2)transform.position + range.center * (_owner.IsFacingRight ? Vector2.right : Vector2.left), range.range.size, 0, _colliders, _targetLayer);

        if (count <= 0) return;
        for (int i = 0; i < count; i++)
        {
            if (_colliders[i].TryGetComponent(out IDamageable health))
            {
                //health.GetDamage(_owner.Stat.damage);
                health.GetDamage(5);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (_attackRange.Length <= 0) return;
        for (int i = 0; i < _attackRange.Length; i++)
        {
            if (i == _attackRange.Length - 1)
                Gizmos.color = Color.blue;
            else
                Gizmos.color = Color.red;
            if (_owner == null)
                Gizmos.DrawWireCube((Vector2)transform.position + _attackRange[i].center, _attackRange[i].range.size);
            else
                Gizmos.DrawWireCube((Vector2)transform.position + _attackRange[i].center * (_owner.IsFacingRight ? Vector2.right : Vector2.left), _attackRange[i].range.size);
        }
    }
#endif
}
