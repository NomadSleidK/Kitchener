using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ZoomState : State
{
    protected readonly StateMachine _stateMachine;

    private Canvas _canvas;
    private Camera _camera;
    private Transform _transform;
    private Joystick _joystick;
    private Transform _targetPoint;

    private float _dirX;
    private float _dirY;
    private float _range = 2.0f;

    public ZoomState(StateMachine stateMachine, Joystick joystick, Canvas canvas, Camera camera, Transform transform, Transform targetPoint)
    {
        _stateMachine = stateMachine;
        _canvas = canvas;
        _camera = camera;
        _transform = transform;
        _joystick = joystick;
        _targetPoint = targetPoint;
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
        DeterminingRange();
        TrajectoryRotation();
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
        _stateMachine.EnterIn<IdleState>();
    }

    private void TrajectoryRotation()
    {
        _dirX = _joystick.Horizontal;
        _dirY = _joystick.Vertical;

        //Debug.Log(_joystick.);
        Vector3 direction = new Vector3(-_dirX, 0, -_dirY);
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, 0.5f);
        }
    }
    private void DeterminingRange()
    {
        _dirX = _joystick.Horizontal;
        _dirY = _joystick.Vertical;
        float mag = Mathf.Clamp01(new Vector2(_dirX, _dirY).magnitude);

        _targetPoint.localPosition = new Vector3(0, 0, _range * mag);
    }
}
