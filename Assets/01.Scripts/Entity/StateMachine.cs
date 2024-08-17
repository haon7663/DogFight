using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine<T> where T : Entity
{
    private T _owner;
    private Dictionary<Enum, State<T>> _stateDictionary = new Dictionary<Enum, State<T>>();
    public State<T> CurrentState { get; private set; }

    public StateMachine(T owner)
    {
        _owner = owner;
        string ownerClassName = typeof(T).ToString();
        Type enumType = Type.GetType(ownerClassName + "StateEnum");

        foreach (Enum stateEnum in Enum.GetValues(enumType))
        {
            string enumName = stateEnum.ToString();
            try
            {
                Type t = Type.GetType(ownerClassName + enumName + "State");
                State<T> state = Activator.CreateInstance(t, owner, this, enumName) as State<T>;
                AddState(state, stateEnum);
            }
            catch(Exception ex)
            {
                Debug.LogError($"{enumName} doesn't exist : {ex}");
            }
        }
    }

    public void Initialize(Enum stateEnum)
    {
        CurrentState = _stateDictionary[stateEnum];
        CurrentState.Enter();
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

    public Enum GetStateEnum() => _stateDictionary.FirstOrDefault(x => x.Value == CurrentState).Key;
}
