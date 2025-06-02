using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    private static bool started = false;
    private static int s_minutes = 0;
    private static int s_seconds = 0;

     [SerializeField] private string sceneToLoad;
    
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

        if (!started)
        {
            s_minutes = minutes;
            s_seconds = seconds;
            started = true;
        }
        
        while (!triggered && enabled)
        {
            yield return m_wait;
            s_seconds--;
            if (s_seconds < 0)
            {
                s_minutes--;
                s_seconds = 59;
            }
            textComponents.ForEach((t)=>t.text = $"{s_minutes:D2}:{s_seconds:D2}");

            if (s_minutes == 0 && s_seconds == 0)
            {
                eventBridgeData.InvokeEvent();
                triggered = true;
                SceneManager.LoadScene(sceneToLoad);
            }
        }

    }
}
