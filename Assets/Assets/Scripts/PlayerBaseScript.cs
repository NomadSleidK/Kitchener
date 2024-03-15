using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private StateMachine _stateMachine;

    [SerializeField] private CurvePath _curvePath;

    [SerializeField] private Camera _camera;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Joystick _joystick;

    private void Start() 
    {
        _canvas.enabled = false;
        _stateMachine = new StateMachine(_curvePath, _canvas, _joystick, _camera, this.transform);
        _stateMachine.EnterIn<IdleState>();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    private void OnMouseEnter()
    {
        _stateMachine.OnMouseEnter();
    }

    private void OnMouseOver()
    {
        _stateMachine.OnMouseOver(Input.mousePosition);
    }

    private void OnMouseExit()
    {
        _stateMachine.OnMouseExit();
    }

    private void OnMouseDown()
    {
        _stateMachine.OnMouseDown();
    }

    private void OnMouseUp()
    {
        _stateMachine.OnMouseUp();
    }

    private void OnCollisionEnter(Collision other)
    {
        _stateMachine.EnterIn<IdleState>();
        
    }
}
