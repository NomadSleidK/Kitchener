using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ZoomState : State
{
    protected readonly StateMachine _stateMachine;

    private Canvas _canvas;
    private Camera _camera;
    private Joystick _joystick;
    private CurvePath _curvePath;

    private Transform _trajectory;

    private float _dirX;
    private float _dirY;

    public ZoomState(StateMachine stateMachine, Joystick joystick, Canvas canvas, Camera camera, CurvePath curvePath)
    {
        _stateMachine = stateMachine;
        _canvas = canvas;
        _camera = camera;
        _joystick = joystick;
        _curvePath = curvePath;
        _trajectory = _curvePath.Trajectory;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider.tag != "Object")
        {
            _canvas.enabled = false;
        }
    }

    public void UpdateState()
    {
        
    }

    public void FixedUpdateState()
    {
        DeterminingRange(); //переустановка целевой позиции
        _curvePath.HightPointPosition(); //установка позиции верхних пределов 
        TrajectoryRotation(); //пращение траектории
    }

    public void OnMouseEnter()
    {
        //throw new System.NotImplementedException();
    }

    public void OnMouseOver(Vector3 mousePosition)
    {
        //throw new System.NotImplementedException();
    }

    public void OnMouseExit()
    {
        //throw new System.NotImplementedException();
    }

    public void OnMouseDown()
    {
        //throw new System.NotImplementedException();
    }

    public void OnMouseUp()
    {
        HowLongExitRange();
    }

    private void TrajectoryRotation()
    {
        _dirX = _joystick.Horizontal;
        _dirY = _joystick.Vertical;

        Vector3 direction = new Vector3(-_dirX, 0, -_dirY);
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            _trajectory.rotation = Quaternion.Lerp(_trajectory.rotation, rotation, 0.5f);
        }
    }

    private void HowLongExitRange()
    {
        _dirX = _joystick.Horizontal;
        _dirY = _joystick.Vertical;
        if(Mathf.Clamp01(new Vector2(_dirX, _dirY).magnitude) >= 0.2f && _curvePath.IsReadyToMove == true)
        {
            _stateMachine.EnterIn<MoveState>();
        }
        else
            _stateMachine.EnterIn<IdleState>();
        _canvas.enabled = false;
    }

    private void DeterminingRange()
    {
        _dirX = _joystick.Horizontal;
        _dirY = _joystick.Vertical;
        _curvePath.SetNewTargetPosition(Mathf.Clamp01(new Vector2(_dirX, _dirY).magnitude));
    }
}
