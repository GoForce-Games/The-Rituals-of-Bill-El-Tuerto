using System;
using UnityEngine;

public class ToggleableObject : MonoBehaviour
{
    public EventBridgeData eventBridgeData;

    private void Start()
    {
        
        eventBridgeData.AddListener(Toggle);
    }

    public void Toggle()
    {
        Debug.Log("Toggled!");
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
