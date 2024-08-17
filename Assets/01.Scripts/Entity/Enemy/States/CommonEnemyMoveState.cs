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
    }

    public override void Exit()
    {
        _owner.AgentCompo.OnMovementEvent -= HandleOnMovementEvent;
        base.Exit();
    }
}
