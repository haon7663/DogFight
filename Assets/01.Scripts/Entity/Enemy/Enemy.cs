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

    [Header("Ground/WallCheck")]
    [SerializeField]
    private Transform _groundChecker;
    [SerializeField]
    private float _groundCheckWidth;
    [SerializeField]
    private float _groundCheckDistance;
    [SerializeField]
    private Transform _wallChecker;
    [SerializeField]
    private float _wallCheckDistance;
    [SerializeField]
    private LayerMask _whatIsGround;
    
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

    public virtual bool IsGroundDetected()
    {
        return (bool)Physics2D.BoxCast(_groundChecker.position, new Vector2(_groundCheckWidth, 0.05f), 0,
            Vector2.down, _groundCheckDistance, _whatIsGround);
    }
    public virtual bool IsWallDetected()
    {
        return (bool)Physics2D.Raycast(_wallChecker.position, IsFacingRight ? Vector2.right : Vector2.left, _wallCheckDistance, _whatIsGround);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

#if UNITY_EDITOR
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (_groundChecker != null)
            Gizmos.DrawWireCube(_groundChecker.position - new Vector3(0, _groundCheckDistance * 0.5f),
                new Vector3(_groundCheckWidth, _groundCheckDistance, 0));
        if (_wallChecker != null)
            Gizmos.DrawLine(_wallChecker.position, _wallChecker.position + new Vector3(_wallCheckDistance, 0, 0));

        Gizmos.color = Color.white;
    }
#endif
}
