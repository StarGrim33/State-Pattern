using System.Collections;
using Unity;
using UnityEngine;

public class WorkState : IStateSwitcher
{
    private StateMachine _machine;

    public WorkState(StateMachine machine)
    {
        _machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered to WorkState");
        Debug.Log("Did some work");
        _machine.SetIdleState();
    }

    public void Exit()
    {
        Debug.Log("Exit WorkState");
    }

    public void Update()
    {
        Debug.Log("Updating WorkState");
    }
}
