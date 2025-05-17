using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private EventBridgeData eventBridgeData;

    [SerializeField] private List<TMP_Text> textComponents;
    
    public int minutes = 1;
    public int seconds = 10;
    
    private WaitForSecondsRealtime m_wait = new WaitForSecondsRealtime(1);
    private bool triggered = false;
    
    private IEnumerator Start()
    {
        if (textComponents.Count == 0)
        {
            textComponents.AddRange(GetComponentsInChildren<TMP_Text>());
            if (textComponents.Count == 0)
            {
                Debug.LogWarning("No text components found");
            }
        }
        
        while (!triggered)
        {
            yield return m_wait;
            seconds--;
            if (seconds < 0)
            {
                minutes--;
                seconds = 59;
            }
            textComponents.ForEach((t)=>t.text = $"{minutes:D2}:{seconds:D2}");

            if (minutes == 0 && seconds == 0)
            {
                eventBridgeData.InvokeEvent();
                triggered = true;
            }
        }

    }
}
