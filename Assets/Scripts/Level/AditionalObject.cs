using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalObject : MonoBehaviour
{
    private TriggerZone _triggerZone;

    private void Start()
    {
        _triggerZone = GameObject.FindGameObjectWithTag("TriggerZone").GetComponent<TriggerZone>();
        Debug.Log(_triggerZone == null);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Object")
        {
            _triggerZone.LevelResult++;
            RemoveObject();
        }
            
    }

    private void RemoveObject()
    {
        gameObject.SetActive(false);
    }
}
