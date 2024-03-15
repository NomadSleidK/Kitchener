using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected readonly StateMachine _stateMachine;

    private Joystick _joystick;
    private Canvas _canvas;
    private CurvePath _curvePath;

    public IdleState(StateMachine stateMachine, Joystick joystick, Canvas canvas, CurvePath curvePath)
    {
        _stateMachine = stateMachine;
        _joystick = joystick;
        _canvas = canvas;
        _curvePath = curvePath;
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

    public void OnMouseOver(Vector3 mousePosition) //если навёлся на объект, то задать начало траектории в начале объекта
    {
        _joystick.transform.position = mousePosition;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Object" && _curvePath.IsReadyToMove == true)
        {
            _curvePath.SetNewPosition(hit.transform);
        }
    }

    public void OnMouseExit()
    {
        _canvas.enabled = false;
    }

    public void OnMouseDown()
    {
        if(_curvePath.IsReadyToMove == true)
            _stateMachine.EnterIn<ZoomState>();
    }

    public void OnMouseUp()
    {
        
    }
}

