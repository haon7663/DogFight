using System;
using UnityEngine;

public enum CommonEnemyStateEnum
{
    Idle,
    Move,
    Hit,
    Attack,
    Dead,
}

public class CommonEnemy : Enemy
{
    public StateMachine<CommonEnemy> StateMachine { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        
        StateMachine = new StateMachine<CommonEnemy>(this);
        StateMachine.Initialize(CommonEnemyStateEnum.Move);
    }
    
    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
    }
    
    public override void AnimationTrigger(AnimationTriggerEnum triggerBit)
    {
        StateMachine.CurrentState.AnimationTrigger(triggerBit);
    }

    public void HandleOnHitEvent()
    {
        StateMachine.ChangeState(CommonEnemyStateEnum.Hit);
    }
}
