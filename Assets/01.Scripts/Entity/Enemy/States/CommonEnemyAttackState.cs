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
        base.Exit();
    }

    public override void UpdateState()
    {
        if (IsTriggerCalled(AnimationTriggerEnum.AttackTrigger))
        {
            if(_owner.DamageCasterCompo.DamageCast(_owner.Data.attackRange[0], _owner.Data.damage, out var targets))
            {
                if (targets[0].TryGetComponent<IDamageable>(out var damageable))
                {
                    damageable.GetDamage(_owner.Data.damage);
                }
            }
            Debug.Log("staAtk");
            RemoveTrigger(AnimationTriggerEnum.AttackTrigger);
        }
        if (IsTriggerCalled(AnimationTriggerEnum.EndTrigger))
        {
            Debug.Log("staMove");
            _stateMachine.ChangeState(CommonEnemyStateEnum.Move);
        }
    }
}
