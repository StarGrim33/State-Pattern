using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private List<Transform> _movementPoints;

    private Dictionary<Type, IStateSwitcher> _states;
    private IStateSwitcher _currentState;

    private void Start()
    {
        Init();
        SetBehaviourByDefault();
    }

    private void Update()
    {
        _currentState?.Update();
    }

    private void Init()
    {
        _states = new Dictionary<Type, IStateSwitcher>
        {
            [typeof(IdleState)] = new IdleState(this),
            [typeof(MovementState)] = new MovementState(_movementPoints, transform, this),
            [typeof(WorkState)] = new WorkState(this)
        };
    }

    private void SetBehaviour(IStateSwitcher state)
    {
        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    private void SetBehaviourByDefault()
    {
        var behaviourByDefault = GetBehaviour<IdleState>();
        SetBehaviour(behaviourByDefault);
    }

    private IStateSwitcher GetBehaviour<T>() where T : IStateSwitcher
    {
        var type = typeof(T);
        return _states[type];
    }

    public void SetIdleState()
    {
        var state = GetBehaviour<IdleState>();
        SetBehaviour(state);
    }

    public void SetMovementState()
    {
        var state = GetBehaviour<MovementState>();
        SetBehaviour(state);
    }

    public void SetWorkState()
    {
        var state = GetBehaviour<WorkState>();
        SetBehaviour(state);
    }
}
