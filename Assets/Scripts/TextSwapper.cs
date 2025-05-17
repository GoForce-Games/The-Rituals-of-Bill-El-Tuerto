using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TextSwapper : MonoBehaviour
{
    public EventBridgeData eventBridgeData;
    
    TMP_Text textComponent;

    [SerializeField] private string storedText;
    [SerializeField] private Color storedColor;

    private void Start()
    {
        textComponent = GetComponentInChildren<TMP_Text>();
        
        EventBridge.instance.AddListener(eventBridgeData.eventName, OnTextSwap);
    }

    public void OnTextSwap()
    {
        (textComponent.text, storedText) = (storedText, textComponent.text);
        (textComponent.color, storedColor) = (storedColor, textComponent.color);
    }
}
