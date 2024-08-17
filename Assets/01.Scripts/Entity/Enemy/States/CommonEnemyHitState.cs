using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyHitState : State<CommonEnemy>
{
    public CommonEnemyHitState(CommonEnemy owner, StateMachine<CommonEnemy> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _owner.MovementCompo.StopImmediately();
        _owner.HealthCompo.OnHitEvent.AddListener(HandleOnHitEvnet);
    }

    private void HandleOnHitEvnet()
    {
        _owner.AnimatorCompo.Play(_owner.AnimatorCompo.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0);
    }

    public override void Exit()
    {
        _owner.HealthCompo.OnHitEvent.RemoveListener(HandleOnHitEvnet);
        base.Exit();
    }

    public override void UpdateState()
    {
        if (IsTriggerCalled(AnimationTriggerEnum.EndTrigger))
        {
            _stateMachine.ChangeState(CommonEnemyStateEnum.Move);
        }
    }
}
