using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationTriggerEnum
{
    EndTrigger,
    AttackTrigger,
    EffectTrigger
}
public abstract class Entity : MonoBehaviour
{
    public Animator AnimatorCompo { get; protected set; }

    public abstract void AnimationTrigger(AnimationTriggerEnum triggerBit);
}
