using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : State<Player>
{
    public PlayerGroundState(Player owner, StateMachine<Player> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _owner.InputCompo.OnJumpEvent += HandleOnJumpEvent;
    }

    public override void UpdateState()
    {
        if(!_owner.IsGround)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }

    private void HandleOnJumpEvent()
    {
        _stateMachine.ChangeState(PlayerStateEnum.Jump);
    }

    public override void Exit()
    {
        _owner.InputCompo.OnJumpEvent -= HandleOnJumpEvent;
        base.Exit();
    }
}
