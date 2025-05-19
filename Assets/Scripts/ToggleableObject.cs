using System;
using UnityEngine;

public class ToggleableObject : MonoBehaviour
{
    public EventBridgeData eventBridgeData;
    
    [SerializeField] private GameObject objectToToggle = null;
    [SerializeField] private MonoBehaviour componentToToggle;

    private void Start()
    {
        eventBridgeData.AddListener(Toggle);
    }

    public void Toggle()
    {
        Debug.Log("Toggled!");
        if (componentToToggle != null)
            componentToToggle.enabled = !componentToToggle.enabled;
        else if (objectToToggle != null)
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        else 
            Debug.Log("Nothing to toggle!");
        
    }
}
