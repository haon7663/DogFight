using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    private Controls _controls;

    public Vector2 Movement { get; private set; } = Vector2.zero;

    public event Action OnAttackEvent;
    public event Action OnJumpEvent;
    public event Action<Vector2> OnMovementEvent;
    public event Action OnThrowEvent;

    private void OnEnable()
    {
        if (_controls == null)
            _controls = new Controls();

        _controls.Player.Enable();
        _controls.Player.SetCallbacks(this);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnAttackEvent?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnJumpEvent?.Invoke();
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Movement = context.ReadValue<Vector2>();
        OnMovementEvent?.Invoke(Movement);
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnThrowEvent?.Invoke();
        }
    }
}
