using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : State<Player>
{
    public PlayerAirState(Player owner, StateMachine<Player> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _owner.InputCompo.OnMovementEvent += HandleOnMovementEvent;
    }

    public override void UpdateState()
    {
        if(_owner.IsGround)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    private void HandleOnMovementEvent(Vector2 movement)
    {
        _owner.MovementCompo.SetMove(movement);
        if (movement.magnitude > 0.5f)
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
