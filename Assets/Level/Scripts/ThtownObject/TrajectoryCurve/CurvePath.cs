using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePath : MonoBehaviour
{
    [SerializeField] private Transform _point0;
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private Transform _point3;
    public Transform TargetPoint => _point3;


    private LineRenderer lineRenderer;
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

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        IsReadyToMove = true;
        ClearLine();
    }

  
    public void DrawCubicBezierCurve()  //отрисовщик кривой
    {
        lineRenderer.positionCount = 50;
        float t = 0.0f;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 point = Curve.GetPoint(_point0.position, _point1.position, _point2.position, _point3.position, t);
            lineRenderer.SetPosition(i, point);
            t += (1 / (float)lineRenderer.positionCount);
        }     
    }
    
    public void ClearLine()
    {
        lineRenderer.positionCount = 0;
    }

    public void SetNewPosition(Transform targetTransform) //установка нового положения кривой
    {
        transform.position = targetTransform.position;

    }

    public Vector3 GetPositionOnCurve(float parameterT) //расчёт позиции на кривой
    {
        return Curve.GetPoint(_point0.position, _point1.position, _point2.position, _point3.position, parameterT);
    }

    public void EditHightPointPosition() //изменение положения верхних пределов от длины кривой
    {
        _point1.transform.localPosition = new Vector3(0, _point1.transform.localPosition.y, _point3.localPosition.z * 0.40f);
        _point2.transform.localPosition = new Vector3(0, _point2.transform.localPosition.y, _point3.localPosition.z * 0.60f);
    }

    public void DeterminingRange(float multiplier) //изменение длины кривой
    {
        _point3.localPosition = new Vector3(_point3.localPosition.x, -1.0f, _range * multiplier);
    }

    public void CurveRotating(Quaternion rotation) //вращение кривой
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.5f);
    }
}
