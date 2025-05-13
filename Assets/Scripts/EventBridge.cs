using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBridge : MonoBehaviour
{
    public static EventBridge instance;

    public List<NamedEvent> events = new List<NamedEvent>();

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            instance.events.AddRange(events);
            Destroy(gameObject);
        }
    }

    public void AddListener(string eventName, UnityAction listener)
    {
        var e = events.Find(e => e.eventName == eventName);
            
        if (e != null)
        {
            e.unityEvent?.AddListener(listener);
        }
        else
        {
            Debug.LogWarning($"Event {eventName} does not exist");
        }
    }

    public void RemoveListener(string eventName, UnityAction listener)
    {
        var e = events.Find(e => e.eventName == eventName);
            if (e != null)
            {
                e.unityEvent?.RemoveListener(listener);
            }
            else
            {
                Debug.LogWarning($"Event {eventName} does not exist");
            }
    }

    public void InvokeEvent(string eventName)
    {
        
        events.Find(e => e.eventName == eventName)?.unityEvent?.Invoke();
    }
}
