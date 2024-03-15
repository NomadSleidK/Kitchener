using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjectScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Object")
        {
            Debug.Log("Попадание");
        }
    }
}
