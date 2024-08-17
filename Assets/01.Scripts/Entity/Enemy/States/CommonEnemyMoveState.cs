using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyMoveState : State<CommonEnemy>
{
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
        if(movement.sqrMagnitude < 0.05f)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void Exit()
    {
        _owner.AgentCompo.OnMovementEvent -= HandleOnMovementEvent;
        base.Exit();
    }
    
    public override void UpdateState()
    {
        /*var target = _enemyBase.target;
        var dir = target.position.x - _enemyBase.transform.position.x;
        var x = (dir > 0 ? 1 : -1) * _enemyBase.data.moveSpeed;
        
        _enemyBase.rigid.velocity = new Vector2(x, _enemyBase.rigid.velocity.y);

        if (_enemyBase.IsTargetDetected())
        {
            _stateMachine.ChangeState(CommonEnemyStateEnum.Attack);
        }*/
    }
}
