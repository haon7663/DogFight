using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player owner, StateMachine<Player> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _owner.MovementCompo.StopImmediately();
        _owner.InputCompo.OnMovementEvent += HandleOnMovementEvent;
    }

    private void HandleOnMovementEvent(Vector2 movement)
    {
        base.UpdateState();
        if(movement.sqrMagnitude > 0.05f)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Move);
        }
    }

    public override void Exit()
    {
        _owner.InputCompo.OnMovementEvent -= HandleOnMovementEvent;
        base.Exit();
    }
}
