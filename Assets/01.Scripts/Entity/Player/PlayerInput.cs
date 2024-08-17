using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private FixedJoystick _joystick;

    public Vector2 MovementDir { get; private set; }
    public Vector2 _prevDir = Vector2.zero;
    public event Action<Vector2> OnMovementEvent;
    public event Action OnJumpEvent;

    private void Awake()
    {
    }

    private void Update()
    {
        if(_prevDir != _joystick.Direction)
        {
            OnMovementEvent?.Invoke(_joystick.Direction);
        }
        MovementDir = _joystick.Direction;
        _prevDir = _joystick.Direction;
    }
}
