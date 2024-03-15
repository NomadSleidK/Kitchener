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

    private float _dirX;
    private float _dirY;

    public ZoomState(StateMachine stateMachine, Joystick joystick, Canvas canvas, Camera camera, CurvePath curvePath)
    {
        _stateMachine = stateMachine;
        _canvas = canvas;
        _camera = camera;
        _joystick = joystick;
        _curvePath = curvePath;
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

        _curvePath.ClearLine();
    }

    public void UpdateState()
    {
        
    }

    public void FixedUpdateState()
    {
        _curvePath.DrawCubicBezierCurve();
        DeterminingRange(); //переустановка целевой позиции
        _curvePath.EditHightPointPosition(); //установка позиции верхних пределов 
        TrajectoryRotation(); //вращение траектории
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

    public void OnMouseUp() //когда мышь отпустили
    {
        HowLengthRange();
    }

    private void TrajectoryRotation()
    {
        _dirX = _joystick.Horizontal;
        _dirY = _joystick.Vertical;

        Vector3 direction = new Vector3(-_dirX, 0, -_dirY);
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            _curvePath.CurveRotating(rotation);
        }
    }

    private void HowLengthRange() //определение состояний от степени натяжения джойстика
    {
        _dirX = _joystick.Horizontal;
        _dirY = _joystick.Vertical;

        if(Mathf.Clamp01(new Vector2(_dirX, _dirY).magnitude) >= 0.1f)
        {
            _stateMachine.EnterIn<MoveState>();
        }
        else
            _stateMachine.EnterIn<IdleState>();

        _canvas.enabled = false;
    }

    private void DeterminingRange() //изменение длины траектории
    {
        _dirX = _joystick.Horizontal;
        _dirY = _joystick.Vertical;

        _curvePath.DeterminingRange(Mathf.Clamp01(new Vector2(_dirX, _dirY).magnitude));
    }
}
