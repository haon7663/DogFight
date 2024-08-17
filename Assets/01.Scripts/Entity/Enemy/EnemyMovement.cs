using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy _enemy;
    public Rigidbody2D RigidbodyCompo { get; private set; }
    [Header("Movement Value")]
    [SerializeField]
    private float _moveSpeed = 8f;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        RigidbodyCompo = GetComponent<Rigidbody2D>();
    }

    public void SetMove(Vector2 dir)
    {
        float yVel = RigidbodyCompo.velocity.y;
        bool flip = dir != Vector2.left;
        _enemy.Flip(flip);
        RigidbodyCompo.velocity = new Vector3(0, yVel, 0) +  (Vector3)(dir * _moveSpeed);
    }

    public void StopImmediately(bool withYAxis = false)
    {
        if(withYAxis)
        {
            RigidbodyCompo.velocity = Vector3.zero;
        }
        float yVel = RigidbodyCompo.velocity.y;
        RigidbodyCompo.velocity = Vector3.zero + new Vector3(0, yVel, 0);
    }
}
