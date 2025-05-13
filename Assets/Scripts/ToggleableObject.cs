using System;
using UnityEngine;

public class ToggleableObject : MonoBehaviour
{
    public EventBridge eventBridge;
    public string eventName;

    private void Start()
    {
        if (eventBridge == null)
            eventBridge = FindObjectOfType<EventBridge>();
        
        eventBridge?.AddListener(eventName, Toggle);
    }

    public void Toggle()
    {
        Debug.Log("Toggled!");
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
