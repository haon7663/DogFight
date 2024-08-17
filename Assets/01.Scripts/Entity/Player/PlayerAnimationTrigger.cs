using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private void AnimationTrigger(AnimationTriggerEnum triggerBit)
    {
        _player.AnimationTrigger(triggerBit);
    }
}
