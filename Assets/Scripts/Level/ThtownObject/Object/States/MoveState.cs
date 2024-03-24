using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected readonly StateMachine _stateMachine;

    private Canvas _canvas;
    private CurvePath _curvePath;
    private Transform _objectTransform;

    private float _parameterT;

    public MoveState(StateMachine stateMachine, Canvas canvas, CurvePath curvePath, Transform objectTransform)
    {
        _stateMachine = stateMachine;
        _canvas = canvas;
        _curvePath = curvePath;
        _objectTransform = objectTransform;
        _parameterT = 0.0f;
    }

    public void Enter()
    {
        _canvas.enabled = false;
    }

    public void Exit()
    {
        _parameterT = 0.0f;
        _curvePath.IsReadyToMove = true;
    }

    public void UpdateState()
    {

    }

    public void FixedUpdateState()
    {
        MoveAlongCurve();
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

    private void MoveAlongCurve()
    {
        if (_parameterT < 1.0f)
        {
            _objectTransform.position = _curvePath.GetPositionOnCurve(_parameterT);
            _parameterT += 1.2f * Time.deltaTime;
        }
        else if(_parameterT >= 1.0f)
            _stateMachine.EnterIn<IdleState>();
    }
}
