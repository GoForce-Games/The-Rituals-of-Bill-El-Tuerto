using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class NamedEvent
{
    public string eventName;
    public UnityEvent unityEvent;
}

[Serializable]
public class EventBridgeData
{
    //Only access in Editor Mode, most likely invalid value in runtime
    [SerializeField] private EventBridge eventBridge;
    
    public string eventName;

    public void AddListener(UnityAction listener) => EventBridge.instance.AddListener(eventName, listener);
    public void InvokeEvent() => EventBridge.instance.InvokeEvent(eventName);
}