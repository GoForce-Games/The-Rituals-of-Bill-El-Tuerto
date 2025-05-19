using System.Collections.Generic;
using System.Linq;
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
            
            #if UNITY_EDITOR
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 120;
            #endif
        }
        else
        {
            var existingEventNames = instance.events.Select((e) => e.eventName).ToList();
            var uniqueEventList = events.Where((e)=> !existingEventNames.Contains(e.eventName)).ToList();
            instance.events.AddRange(uniqueEventList);
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
