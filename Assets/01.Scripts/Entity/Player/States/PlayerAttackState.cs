using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttackState : State<Player>
{
    private Animator _handAnimator;
    private float _lastAttackTime;
    private float _comboInitTime = 0.7f;
    private int _comboCounter = 0;
    private readonly int _comboCounterHash = Animator.StringToHash("ComboCounter");

    public PlayerAttackState(Player owner, StateMachine<Player> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
        _handAnimator = _owner.transform.Find("Hand").GetComponent<Animator>();
    }

    public override void Enter()
    {
        base.Enter();
        if (_lastAttackTime + _comboInitTime > Time.time || _comboCounter > 2)
            _comboCounter = 0;

        _handAnimator.SetInteger(_comboCounterHash, _comboCounter);
    }

    public override void Exit()
    {
        _lastAttackTime = Time.time;
        base.Exit();
    }
}
