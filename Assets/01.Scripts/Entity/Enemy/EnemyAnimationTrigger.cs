using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour
{
    [SerializeField]
    private Enemy _enemy;

    private void AnimationTrigger(AnimationTriggerEnum triggerBit)
    {
        _enemy.AnimationTrigger(triggerBit);
    }
}
