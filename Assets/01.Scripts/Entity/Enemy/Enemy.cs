using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Enemy : Entity
{
    public EnemyMovement MovementCompo { get; private set; }
    public EnemyAgent AgentCompo { get; private set; }
    public DamageCaster DamageCasterCompo { get; private set; }
    [field: SerializeField] public EnemySO Data { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        MovementCompo = GetComponent<EnemyMovement>();
        MovementCompo.Initialize(this);
        AgentCompo = GetComponent<EnemyAgent>();
    }

    
    /*private void FixedUpdate()
    {
        var hit = Physics2D.OverlapBox((Vector2)transform.position + data.rect.position,
            data.rect.size, 0, targetLayer);

        if (hit)
        {
            print($"충돌한 객체: {hit.name}");
        }
        
        var dir = target.position.x - transform.position.x;
        var x = (dir > 0 ? 1 : -1) * data.moveSpeed;
        
        rigid.velocity = new Vector2(x, rigid.velocity.y);
    }*/
    
    public override void AnimationTrigger(AnimationTriggerEnum triggerBit)
    {
        
    }

    [CanBeNull]
    public virtual Collider2D IsTargetDetected()
    {
        var hit = Physics2D.OverlapBox((Vector2)transform.position + Data.rect.position,
            Data.rect.size, 0);

        return hit;
    }

    private void OnDrawGizmos()
    {
        if (!Data)
            return;
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((Vector2)transform.position + Data.rect.position, Data.rect.size);
    }
}
