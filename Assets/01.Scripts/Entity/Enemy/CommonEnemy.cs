using System;
using UnityEngine;

public class CommonEnemy : Enemy
{
    private EnemyStateMachine<CommonEnemyStateEnum> _stateMachine;
    public EnemyStateMachine<CommonEnemyStateEnum> StateMachine => _stateMachine;
    
    protected override void Awake()
    {
        base.Awake();
        
        foreach (CommonEnemyStateEnum stateEnum in Enum.GetValues(typeof(CommonEnemyStateEnum)))
        {
            string typeName = stateEnum.ToString();
            Type t = Type.GetType($"CommonEnemy{typeName}State");
            try
            {
                var enemyState = Activator.CreateInstance(t, this, _stateMachine, typeName) as EnemyState<CommonEnemyStateEnum>;
                _stateMachine.AddState(stateEnum, enemyState);
            }
            catch (Exception e)
            {
                Debug.LogError($"CommonEnemy : no state [ {typeName} ]");
                Debug.LogError(e);
            }
        }
    }
}
