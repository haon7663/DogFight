using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T> where T : Entity
{
    protected T _owner;
    protected StateMachine<T> _stateMachine;
    protected int _animBoolHash;
    protected int _animationTriggerBit;

    public State(T owner, StateMachine<T> stateMachine, string animBoolName)
    {
        _owner = owner;
        _stateMachine = stateMachine;
        _animBoolHash = Animator.StringToHash(animBoolName);
    }

    public virtual void Enter()
    {
        _owner.AnimatorCompo.SetBool(_animBoolHash, true);
        _animationTriggerBit = 0;
    }
    public virtual void UpdateState() { }
    public virtual void Exit() 
    {
        _owner.AnimatorCompo.SetBool(_animBoolHash, false);
    }

    public void AnimationTrigger(AnimationTriggerEnum bit)
    {
        _animationTriggerBit |= (int)bit;
    }

    public bool IsTriggerCalled(AnimationTriggerEnum bit)
        => (_animationTriggerBit & (int)bit) != 0;
    public void RemoveTrigger(AnimationTriggerEnum bit)
        => _animationTriggerBit &= ~(int)bit;
}
