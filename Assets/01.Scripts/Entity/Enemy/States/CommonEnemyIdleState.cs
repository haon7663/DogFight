using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyIdleState : State<CommonEnemy>
{
    public CommonEnemyIdleState(CommonEnemy owner, StateMachine<CommonEnemy> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        _owner.MovementCompo.StopImmediately();
        _owner.AgentCompo.OnMovementEvent += HandleOnMovementEvent;
        HandleOnMovementEvent(_owner.AgentCompo.MovementDir);
    }

    private void HandleOnMovementEvent(Vector2 movement)
    {
        base.UpdateState();
        if(movement.magnitude > 0.05f)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Move);
        }
    }

    public override void Exit()
    {
        _owner.AgentCompo.OnMovementEvent -= HandleOnMovementEvent;
        base.Exit();
    }
}
