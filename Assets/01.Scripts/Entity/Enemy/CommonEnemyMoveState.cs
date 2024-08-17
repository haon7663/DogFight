using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyMoveState : EnemyState<CommonEnemyStateEnum>
{
    public override void UpdateState()
    {
        var target = _enemyBase.target;
        var dir = target.position.x - _enemyBase.transform.position.x;
        var x = (dir > 0 ? 1 : -1) * _enemyBase.data.moveSpeed;
        
        _enemyBase.rigid.velocity = new Vector2(x, _enemyBase.rigid.velocity.y);

        if (_enemyBase.IsTargetDetected())
        {
            _stateMachine.ChangeState(CommonEnemyStateEnum.Attack);
        }
    }
}
