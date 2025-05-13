using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ToggleSource : MonoBehaviour
{
    public EventBridge eventBridge;
    public string eventName;
    
    private bool m_triggered = false;

    [SerializeField] private float rotation = 4.5f;

    private void Start()
    {
        if (eventBridge == null)
            eventBridge = FindObjectOfType<EventBridge>();
    }
    
    public void Toggle()
    {
        m_triggered = !m_triggered;
        transform.localRotation = Quaternion.Euler((m_triggered ? (Vector3.right * 4.5f) : Vector3.zero));
        Debug.Log(transform.localEulerAngles.ToString());

        eventBridge?.InvokeEvent(eventName);
    }
}
