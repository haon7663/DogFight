using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateEnum
{
    Idle,
    Move,
    Hit,
    Attack,
    Jump,
    Fall,
    Dead,
}

public class Player : Entity
{
    public StateMachine<Player> StateMachine { get; private set; }
    public PlayerMovement MovementCompo { get; private set; }
    [field:SerializeField]
    public InputReader InputCompo { get; private set; }
    public DamageCaster DamageCasterCompo { get; private set; }
    public bool IsGround => IsGroundDetected();
    [field: SerializeField]
    public Transform WeaponTrm { get; private set; }

    [Header("Ground Check")]
    [SerializeField]
    private Transform _groundChecker;
    [SerializeField]
    private float _groundCheckBoxWidth;
    [SerializeField]
    private float _groundCheckDistance;
    [SerializeField]
    private LayerMask _whatIsGround;

    protected override void Awake()
    {
        base.Awake();
        MovementCompo = GetComponent<PlayerMovement>();
        MovementCompo.Initialize(this);
        StateMachine = new StateMachine<Player>(this);

        StateMachine.Initialize(PlayerStateEnum.Idle);
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }

    public override void AnimationTrigger(AnimationTriggerEnum triggerBit)
    {
        StateMachine.CurrentState.AnimationTrigger(triggerBit);
    }

    private bool IsGroundDetected()
    {
        return Physics2D.BoxCast(_groundChecker.position, new Vector2(_groundCheckBoxWidth, 0.05f), 0, Vector2.down, _groundCheckDistance, _whatIsGround);
    }

#if UNITY_EDITOR
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (_groundChecker != null)
            Gizmos.DrawWireCube(_groundChecker.position - new Vector3(0, _groundCheckDistance * 0.5f),
                new Vector3(_groundCheckBoxWidth, _groundCheckDistance, 1f));
        Gizmos.color = Color.white;
    }
#endif
}
