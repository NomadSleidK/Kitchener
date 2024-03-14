using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected readonly StateMachine _stateMachine;

    private Joystick _joystick;
    private Canvas _canvas;
    private CurvePath _curvePath;

    public MoveState(StateMachine stateMachine, Joystick joystick, Canvas canvas, CurvePath curvePath)
    {
        _stateMachine = stateMachine;
        _joystick = joystick;
        _canvas = canvas;
        _curvePath = curvePath;
    }

    public void Enter()
    {
        _canvas.enabled = false;
        _curvePath.IsReadyToMove = false;
    }

    public void Exit()
    {
        _curvePath.ParametrT = 0.0f;
        _curvePath.IsReadyToMove = true;
    }

    public void UpdateState()
    {

    }

    public void FixedUpdateState()
    {
        Move();
    }

    public void OnMouseEnter()
    {
        
    }

    public void OnMouseOver(Vector3 mousePosition)
    {
        
    }

    public void OnMouseExit()
    {
        
    }

    public void OnMouseDown()
    {
        
    }

    public void OnMouseUp()
    {
        
    }

    private void Move()
    {
        if (_curvePath.ParametrT < 1.0f)
        {
            _curvePath.Move();
            _curvePath.ParametrT += 1.0f * Time.deltaTime;
        }
        else if(_curvePath.ParametrT >= 1.0f)
            _stateMachine.EnterIn<IdleState>();
    }
}
