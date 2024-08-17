using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyHitState : State<CommonEnemy>
{
    public CommonEnemyHitState(CommonEnemy owner, StateMachine<CommonEnemy> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }
}