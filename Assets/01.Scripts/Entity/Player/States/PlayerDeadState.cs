using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : State<Player>
{
    public PlayerDeadState(Player owner, StateMachine<Player> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }
}
