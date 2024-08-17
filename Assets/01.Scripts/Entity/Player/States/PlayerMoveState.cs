using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player owner, StateMachine<Player> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _owner.InputCompo.OnMovementEvent += HandleOnMovementEvent;
    }

    private void HandleOnMovementEvent(Vector2 movement)
    {
        _owner.MovementCompo.SetMove(movement);
        if(movement.magnitude < 0.05f)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void Exit()
    {
        _owner.InputCompo.OnMovementEvent -= HandleOnMovementEvent;
        base.Exit();
    }

}
