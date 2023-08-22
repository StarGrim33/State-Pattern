using System.Collections.Generic;
using UnityEngine;

public class MovementState : IStateSwitcher
{
    private StateMachine _machine;
    private List<Transform> _movePoints;
    private Transform _npcTransform;
    private Transform _lastPoint;
    private int _currentPointIndex = 0;

    public MovementState(List<Transform> points, Transform npcTransform, StateMachine machine)
    {
        _movePoints = points;
        _npcTransform = npcTransform;
        _machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered to MovementState");
    }

    public void Exit()
    {
        Debug.Log("Exit MovementState");
    }

    public void Update()
    {
        if (_movePoints.Count > 0 && _currentPointIndex < _movePoints.Count)
        {
            _lastPoint = _movePoints[_currentPointIndex];
            _npcTransform.position = Vector3.MoveTowards(_npcTransform.position, _lastPoint.position, Time.deltaTime * 2f);

            if (Vector3.Distance(_npcTransform.position, _lastPoint.position) < 0.01f)
            {
                _currentPointIndex++;
                if (_currentPointIndex >= _movePoints.Count)
                {
                    _currentPointIndex = 0;
                    _machine.SetWorkState();
                }
            }
        }
    }
}
