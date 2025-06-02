using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class VRSetup : MonoBehaviour
{
    [SerializeField] private Toggle sitStandToggle;
    
    // Start is called before the first frame update
    void Start()
    {
        bool isSitting = PlayerPrefs.GetInt("Sitting", 0) > 0;
        var xrOrigin = GetComponent<XROrigin>();
        xrOrigin.RequestedTrackingOriginMode =
            (isSitting ? XROrigin.TrackingOriginMode.Device : XROrigin.TrackingOriginMode.Floor);

        if (sitStandToggle)
        {
            sitStandToggle.isOn = isSitting;
        }
    }

    public void OnStandSitToggle(bool isSitting)
    {
        PlayerPrefs.SetInt("Sitting", isSitting? 1 : 0);
        Start();
    }
}
