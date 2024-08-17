using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyIdleState : State<CommonEnemy>
{
    public CommonEnemyIdleState(CommonEnemy owner, StateMachine<CommonEnemy> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }
}
