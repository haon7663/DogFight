using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyDeadState : State<CommonEnemy>
{
    public CommonEnemyDeadState(CommonEnemy owner, StateMachine<CommonEnemy> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }
}
