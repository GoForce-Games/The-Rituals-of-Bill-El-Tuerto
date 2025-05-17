using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ToggleSource : MonoBehaviour
{
    public EventBridgeData eventBridgeData;
    
    private bool m_triggered = false;

    [SerializeField] private float rotation = 4.5f;

    private void Start()
    {
    }
    
    public void Toggle()
    {
        m_triggered = !m_triggered;
        transform.localRotation = Quaternion.Euler((m_triggered ? (Vector3.right * rotation) : Vector3.zero));
        Debug.Log(transform.localEulerAngles.ToString());

        eventBridgeData.InvokeEvent();
    }
}
