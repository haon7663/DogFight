using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageCaster : MonoBehaviour
{
    [SerializeField]
    protected LayerMask _targetLayer;
    protected Entity _owner;
    

    public void Initialize(Entity owner)
    {
        _owner = owner;
        _owner.OnFlipEvent += FlipCaster;
    }

    public abstract void DamageCast(int combo);

    private void FlipCaster(bool value)
    {
        float angle = value ? 180f : 0f;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
