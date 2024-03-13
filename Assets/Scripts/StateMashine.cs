using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class StateMachine
{
    private Dictionary<Type, State> _states;
    private State _currentState;
    public State CurrentState => _currentState;

    private CurvePath _curvePath;
    private Canvas _canvas;
    private Joystick _joystick;
    private Camera _camera;
    private Transform _transform;
    private Transform _targetPoint;

    public StateMachine(CurvePath curvePath, Canvas canvas, Joystick joystick, Camera camera, Transform transform, Transform targetPoint)
    {
        _curvePath = curvePath;
        _canvas = canvas;
        _joystick = joystick;
        _camera = camera;
        _transform = transform;
        _targetPoint = targetPoint;

        _states = new Dictionary<Type, State>()
        {
            [typeof(IdleState)] = new IdleState(this, _joystick, _canvas),
            [typeof(ZoomState)] = new ZoomState(this, _joystick, _canvas, _camera, _transform, _targetPoint),
        };
        _targetPoint = targetPoint;
    }

    public void EnterIn<TState>() where TState : State
    {
        if (_states.TryGetValue(typeof(TState), out State state))
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState?.Enter();
        }
    }

    public void Update()
    {
        _currentState.UpdateState();
    }

    public void FixedUpdate()
    {
        _currentState.FixedUpdateState();
    }

    public void OnMouseEnter()
    {
        _currentState.OnMouseEnter();
    }

    public void OnMouseExit()
    {
        _currentState.OnMouseExit();
    }
    public void OnMouseOver(Vector3 mousePosition)
    {
        _currentState.OnMouseOver(mousePosition);
    }

    public void OnMouseDown()
    {
        _currentState.OnMouseDown();
    }

    public void OnMouseUp()
    {
        _currentState.OnMouseUp();
    }
}
