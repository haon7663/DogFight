using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : MonoBehaviour
{
    public Vector2 MovementDir { get; private set; }
    private Vector2 _prevDir = Vector2.zero;
    public event Action<Vector2> OnMovementEvent;

    private Transform _target;

    private void Start()
    {
        _target = BattleController.Inst.player.transform;
    }

    private void Update()
    {
        var distance = _target.position.x - transform.position.x;
        MovementDir = new Vector2(distance == 0 ? 0 : (distance > 0 ? 1 : -1), 0);
        OnMovementEvent?.Invoke(MovementDir);
        _prevDir = MovementDir;
    }
}
