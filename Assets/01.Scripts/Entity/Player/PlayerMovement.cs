using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;
    public Rigidbody2D RigidbodyCompo { get; private set; }
    [Header("Movement Value")]
    [SerializeField]
    private float _moveSpeed = 8f;
    [SerializeField]
    private float _jumpPower = 5f;
    private Vector2 _movement;

    public void Initialize(Player player)
    {
        _player = player;
        RigidbodyCompo = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RigidbodyCompo.velocity = new Vector2(0, RigidbodyCompo.velocity.y) + _movement;
    }

    public void SetMove(Vector2 dir)
    {
        if (dir != Vector2.zero)
        {
            bool flip = dir == Vector2.left ? true : false;
            _player.Flip(flip);
        }
        _movement = dir * _moveSpeed;
    }

    public void Jump()
    {
        RigidbodyCompo.AddForce(Vector3.up * _jumpPower, ForceMode2D.Impulse);
    }

    public void StopImmediately(bool withYAxis = false)
    {
        if (withYAxis)
        {
            RigidbodyCompo.velocity = Vector3.zero;
        }
        float yVel = RigidbodyCompo.velocity.y;
        RigidbodyCompo.velocity = Vector3.zero + new Vector3(0, yVel, 0);
    }
}
