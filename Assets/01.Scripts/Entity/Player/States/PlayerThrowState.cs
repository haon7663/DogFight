using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowState : State<Player>
{
    public PlayerThrowState(Player owner, StateMachine<Player> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
}
