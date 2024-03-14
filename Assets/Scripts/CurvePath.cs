using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePath : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Transform _trajectory;
    public Transform Trajectory => _trajectory;

    [SerializeField] private Transform _point0;
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private Transform _point3;
    public Transform TargetPoint => _point3;

    private float _range = 2.0f;
    private bool _isReadyToMove;
    public bool IsReadyToMove
    {
        get
        {
            return _isReadyToMove;
        }
        set
        {
            _isReadyToMove = value;
        }
    }

    private float _parametrT;
    public float ParametrT
    {
        get
        {
            return _parametrT;
        }
        set
        {
            if (value > 1)
                _parametrT = 1.0f;
            else if (value >= 0 && value <= 1)
                _parametrT = value;
        }

    }

    private void Start()
    {
        IsReadyToMove = true;
    }

    private void OnDrawGizmos() {

        int sigmentsNumber = 20;
        Vector3 preveousePoint = _point0.position;

        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = Curve.GetPoint(_point0.position, _point1.position, _point2.position, _point3.position, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }

    public void SetNewPosition()
    {
        _trajectory.position = this.transform.position;

    }

    public void Move()
    {
        transform.position = Curve.GetPoint(_point0.position, _point1.position, _point2.position, _point3.position, _parametrT);
    }

    public void HightPointPosition()
    {
        _point1.transform.localPosition = new Vector3(0, _point1.transform.localPosition.y, _point3.localPosition.z * 0.40f);
        _point2.transform.localPosition = new Vector3(0, _point2.transform.localPosition.y, _point3.localPosition.z * 0.60f);
    }

    public void SetNewTargetPosition(float expiditor)
    {
        _point3.localPosition = new Vector3(_point3.localPosition.x, _point3.localPosition.y, _range * expiditor);
    }
}
