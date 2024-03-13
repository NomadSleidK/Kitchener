using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePath : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    [SerializeField] private Transform _point0;
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private Transform _point3;

    [Range(0,1)]
    [SerializeField] private float t;

    void Update()
    {
        ObjectMove();
        HightPointPosition();
    }

    private void OnDrawGizmos() {

        int sigmentsNumber = 20;
        Vector3 preveousePoint = _point0.position;

        for (int i = 0; i < sigmentsNumber + 1; i++) {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = Curve.GetPoint(_point0.position, _point1.position, _point2.position, _point3.position, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }

    private void ObjectMove()
    {
        transform.position = Curve.GetPoint(_point0.position, _point1.position, _point2.position, _point3.position, t);
        //transform.rotation = Quaternion.LookRotation(Curve.GetFirstDerivative(_point0.position, _point1.position, _point2.position, _point3.position, t));
    }

    private void HightPointPosition()
    {
        _point1.transform.localPosition = new Vector3(0, _point1.transform.localPosition.y, _point3.localPosition.z * 0.40f);
        _point2.transform.localPosition = new Vector3(0, _point2.transform.localPosition.y, _point3.localPosition.z * 0.60f);
    }
}
