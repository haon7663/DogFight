using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(Player owner, StateMachine<Player> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _owner.MovementCompo.Jump();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log(_owner.MovementCompo.RigidbodyCompo.velocity.y);
        if(_owner.MovementCompo.RigidbodyCompo.velocity.y < 0)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }
}
