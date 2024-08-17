using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : MonoBehaviour
{
    [SerializeField] private Transform target; //임시
    
    public Vector2 MovementDir { get; private set; }
    private Vector2 _prevDir = Vector2.zero;
    public event Action<Vector2> OnMovementEvent;

    private void Update()
    {
        var distance = target.position.x - transform.position.x;
        MovementDir = new Vector2(distance == 0 ? 0 : (distance > 0 ? 1 : -1), 0);
        OnMovementEvent?.Invoke(MovementDir);
        _prevDir = MovementDir;
    }
}
