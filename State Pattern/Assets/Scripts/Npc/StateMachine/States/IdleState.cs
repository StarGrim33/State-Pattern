using UnityEngine;

public class IdleState : IStateSwitcher
{
    private StateMachine _machine;
    private float _duration = 5f;
    private float _timer;

    public IdleState(StateMachine machine)
    {
        _machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered to IdleState");
    }

    public void Exit()
    {
        Debug.Log("Exit IdleState");
    }

    public void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > _duration)
        {
            _machine.SetMovementState();
        }
    }
}
