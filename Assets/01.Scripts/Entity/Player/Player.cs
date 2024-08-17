using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Rendering;

public enum PlayerStateEnum
{
    Idle,
    Move,
    Hit,
    Jump,
    Fall,
    Dead,
}

public class Player : Entity
{
    public StateMachine<Player> StateMachine { get; private set; }
    public PlayerMovement MovementCompo { get; private set; }
    public PlayerWeapon WeaponCompo { get; private set; }
    [field: SerializeField]
    public InputReader InputCompo { get; private set; }
    public DamageCaster DamageCasterCompo { get; private set; }
    public IInteractable NearestInteractableObj { get; private set; }
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

    [Header("Interactable Object Search")]
    [SerializeField]
    private float _radius = 3f;
    [SerializeField]
    private int _maxSearch = 5;
    [SerializeField]
    private LayerMask _whatIsInteractable;
    private Collider2D[] _colliders;

    protected override void Awake()
    {
        base.Awake();
        MovementCompo = GetComponent<PlayerMovement>();
        MovementCompo.Initialize(this);
        WeaponCompo = GetComponent<PlayerWeapon>();
        StateMachine = new StateMachine<Player>(this);

        StateMachine.Initialize(PlayerStateEnum.Idle);

        InputCompo.OnAttackEvent += () => WeaponCompo.Attack();
        InputCompo.OnInteractEvent += () => WeaponCompo.Interaction();

        _colliders = new Collider2D[_maxSearch];
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
        SearchInteractableObject();
    }

    private void SearchInteractableObject()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _colliders, _whatIsInteractable);

        if (count <= 0) return;
        Collider2D nearest = null;
        for (int i = 0; i < count; i++)
        {
            if (nearest == null)
            {
                nearest = _colliders[i];
                continue;
            }
            if(Vector2.Distance(transform.position, nearest.transform.position) > Vector2.Distance(transform.position, _colliders[i].transform.position)) 
            {
                nearest = _colliders[i];
            }
        }

        NearestInteractableObj = nearest.GetComponent<IInteractable>();
        NearestInteractableObj.GameObject = nearest.gameObject;
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
