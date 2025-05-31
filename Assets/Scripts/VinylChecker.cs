using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class VinylChecker : MonoBehaviour
{
    [SerializeField] EventBridgeData eventBridgeData;
    
    // List of sockets from which to read the values
    [SerializeField] List<XRSocketInteractor> sockets = new List<XRSocketInteractor>();

    [SerializeField] private int[] order;
    
    // Start is called before the first frame update
    void Start()
    {
        if (sockets.Count != order.Length)
        {
            Debug.LogWarning("Mismatch between vinyl sockets count and password length");
            enabled = false;
        }
    }

    public void CheckVinyls()
    {
        if (sockets.Count <= 0 || sockets.Count != order.Length)
        {
            Debug.LogError("VinylChecker not properly configured");
            return;
        }
        
        for (int i = 0; i < order.Length; i++)
        {
            var selected = sockets[i].GetOldestInteractableSelected();
            if (selected != null)
            {
                var vinyl = selected.transform.GetComponent<VinylData>();
                if (vinyl.number != order[i])
                {
                    return;
                }
            }
            else
                return;
        }

        Debug.Log("Password correct!");
        eventBridgeData.InvokeEvent();
    }
    
}
