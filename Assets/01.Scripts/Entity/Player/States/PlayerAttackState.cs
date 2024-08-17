using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State<Player>
{
    public PlayerAttackState(Player owner, StateMachine<Player> stateMachine, string animBoolName) : base(owner, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _owner.MovementCompo.StopImmediately();
        switch (_owner.CurrentWeapon.weaponType)
        {
            case WeaponType.OneHand:
                // 여기들에
                break;
            case WeaponType.TwoHands:
                break;
            case WeaponType.ShortSword:
                // 추가
                break;
        }
    }
}
