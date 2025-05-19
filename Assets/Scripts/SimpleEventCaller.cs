using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEventCaller : MonoBehaviour
{
    [SerializeField] private EventBridgeData m_eventBridgeData;
    
    
    public void InvokeEvent() => m_eventBridgeData.InvokeEvent();
    
}
