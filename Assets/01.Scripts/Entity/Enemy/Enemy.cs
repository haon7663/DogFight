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
    public SquareDamageCaster DamageCasterCompo { get; private set; }
    [field: SerializeField] public EnemySO Data { get; private set; }

    [SerializeField] private Animator animator;
    
    protected override void Awake()
    {
        base.Awake();
        MovementCompo = GetComponent<EnemyMovement>();
        MovementCompo.Initialize(this);
        AgentCompo = GetComponent<EnemyAgent>();
        DamageCasterCompo = GetComponent<SquareDamageCaster>();
    }

    public void Initialize(EnemySO data)
    {
        Data = data;
        MovementCompo.moveSpeed = data.moveSpeed;
        animator.runtimeAnimatorController = data.animatorController;
    }
    
    public bool IsTargetDetected()
    {
        var hit = DamageCasterCompo.InRange(Data.attackRange[0]);
        return hit;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
