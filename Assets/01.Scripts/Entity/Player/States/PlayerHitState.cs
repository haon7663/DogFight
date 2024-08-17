using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : State<Player>
{
    public PlayerHitState(Player owner, StateMachine<Player> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }
}
