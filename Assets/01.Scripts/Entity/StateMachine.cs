using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine<T> where T : Entity
{
    private T _owner;
    private Dictionary<Enum, State<T>> _stateDictionary;
    public State<T> CurrentState { get; private set; }

    public StateMachine(T owner)
    {
        _owner = owner;
    }

    public void AddState(State<T> state, Enum stateEnum)
    {
        _stateDictionary.Add(stateEnum, state);
    }

    public void ChangeState(Enum newState)
    {
        CurrentState.Exit();
        CurrentState = _stateDictionary[newState];
        CurrentState.Enter();
    }
}
