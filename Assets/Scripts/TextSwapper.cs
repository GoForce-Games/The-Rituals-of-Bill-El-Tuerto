using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TextSwapper : MonoBehaviour
{
    public EventBridge eventBridge;
    public string eventName;
    
    TMP_Text textComponent;

    [SerializeField] private string storedText;
    [SerializeField] private Color storedColor;

    private void Start()
    {
        textComponent = GetComponentInChildren<TMP_Text>();
        
        if (eventBridge == null)
            eventBridge = FindObjectOfType<EventBridge>();
        
        eventBridge?.AddListener(eventName, OnTextSwap);
    }

    public void OnTextSwap()
    {
        (textComponent.text, storedText) = (storedText, textComponent.text);
        (textComponent.color, storedColor) = (storedColor, textComponent.color);
    }
}
