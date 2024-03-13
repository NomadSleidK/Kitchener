using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected readonly StateMachine _stateMachine;

    private Joystick _joystick;
    private Canvas _canvas;

    public IdleState(StateMachine stateMachine, Joystick joystick, Canvas canvas)
    {
        _stateMachine = stateMachine;
        _joystick = joystick;
        _canvas = canvas;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {

    }

    public void UpdateState()
    {
        
    }

    public void FixedUpdateState()
    {
        
    }

    public void OnMouseEnter()
    {
        _canvas.enabled = true;
    }

    public void OnMouseOver(Vector3 mousePosition)
    {
        _joystick.transform.position = mousePosition;
    }

    public void OnMouseExit()
    {
        _canvas.enabled = false;
    }

    public void OnMouseDown()
    {
        _stateMachine.EnterIn<ZoomState>();
    }

    public void OnMouseUp()
    {
        //throw new System.NotImplementedException();
    }
}

