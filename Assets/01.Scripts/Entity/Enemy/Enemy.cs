using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Enemy : MonoBehaviour
{
    [field: SerializeField] public EnemySO data { get; private set; }
    [SerializeField] private LayerMask targetLayer;
    
    public Rigidbody2D rigid;
    public Animator anim;
    public Transform target;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Initialize(EnemySO data)
    {
        this.data = data;
    }
    
    /*private void FixedUpdate()
    {
        var hit = Physics2D.OverlapBox((Vector2)transform.position + data.rect.position,
            data.rect.size, 0, targetLayer);

        if (hit)
        {
            print($"충돌한 객체: {hit.name}");
        }
        
        var dir = target.position.x - transform.position.x;
        var x = (dir > 0 ? 1 : -1) * data.moveSpeed;
        
        rigid.velocity = new Vector2(x, rigid.velocity.y);
    }*/

    [CanBeNull]
    public virtual Collider2D IsTargetDetected()
    {
        var hit = Physics2D.OverlapBox((Vector2)transform.position + data.rect.position,
            data.rect.size, 0, targetLayer);

        return hit;
    }

    private void OnDrawGizmos()
    {
        if (!data)
            return;
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((Vector2)transform.position + data.rect.position, data.rect.size);
    }
}
