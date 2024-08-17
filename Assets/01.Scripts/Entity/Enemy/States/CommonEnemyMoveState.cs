using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyMoveState : State<CommonEnemy>
{
    private Coroutine _coroutine;
    
    public CommonEnemyMoveState(CommonEnemy owner, StateMachine<CommonEnemy> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        _owner.AgentCompo.OnMovementEvent += HandleOnMovementEvent;
    }

    private void HandleOnMovementEvent(Vector2 movement)
    {
        _owner.MovementCompo.SetMove(movement);
        if(_owner.IsGroundDetected() && _owner.IsWallDetected() && _owner.MovementCompo.RigidbodyCompo.velocity.y < 0.5f)
        {
            _owner.MovementCompo.Jump();
        }
        if (_owner.IsTargetDetected() && _coroutine == null)
        {
            _coroutine = _owner.StartCoroutine(ChangeAttackState());
        }
    }

    private IEnumerator ChangeAttackState()
    {
        yield return null;
        _stateMachine.ChangeState(CommonEnemyStateEnum.Attack);
        _coroutine = null;
    }

    public override void Exit()
    {
        _owner.AgentCompo.OnMovementEvent -= HandleOnMovementEvent;
        base.Exit();
    }
}
