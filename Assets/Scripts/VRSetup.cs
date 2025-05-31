using Unity.XR.CoreUtils;
using UnityEngine;

public class VRSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var isSitting = PlayerPrefs.GetInt("Sitting", 0);
        var xrOrigin = GetComponent<XROrigin>();
        xrOrigin.RequestedTrackingOriginMode =
            (isSitting > 0 ? XROrigin.TrackingOriginMode.Device : XROrigin.TrackingOriginMode.Floor);
    }

    public void OnStandSitToggle(bool isSitting)
    {
        PlayerPrefs.SetInt("Sitting", isSitting? 1 : 0);
        Start();
    }
}
