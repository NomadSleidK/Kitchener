using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private Transform _targetObject;

    private void Update()
    {
        this.transform.position = _targetObject.position;
        this.transform.rotation = _targetObject.rotation;
    }
}
