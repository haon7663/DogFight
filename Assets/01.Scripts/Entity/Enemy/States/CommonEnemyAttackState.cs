using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyAttackState : State<CommonEnemy>
{
    public CommonEnemyAttackState(CommonEnemy owner, StateMachine<CommonEnemy> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        
    }
}
