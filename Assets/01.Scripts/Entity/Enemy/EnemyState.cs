using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState<T> where T : Enum
{
    protected EnemyStateMachine<T> _stateMachine;
    protected Enemy _enemyBase;
    protected bool _endTriggerCalled;

    
    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }
    
    public virtual void UpdateState()
    {
        
    }

    public void AnimationEndTrigger()
    {
        _endTriggerCalled = true;
    }
}
