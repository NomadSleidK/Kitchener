using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private StateMachine _stateMachine;
    private CurvePath _curvePath;
    [SerializeField] private Camera _camera;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Transform _targetPoint;


    private void Start() 
    {
        _canvas.enabled = false;
        _curvePath = GetComponent<CurvePath>();
        _stateMachine = new StateMachine(_curvePath, _canvas, _joystick, _camera, this.gameObject.transform, _targetPoint);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Triggered");
        }
    }
}
