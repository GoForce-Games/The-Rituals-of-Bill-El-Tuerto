using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;

public class MountTractor : MonoBehaviour
{
    public Transform mountPoint;
    public XROrigin xrRig;
    private DriveTractor driveTractor;

    private void Start()
    {
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        driveTractor = GetComponent<DriveTractor>();

        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntered);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Mount();
    }

    void Mount()
    {
        if (xrRig != null && mountPoint != null)
        {
            Vector3 offset = xrRig.Camera.transform.position - xrRig.transform.position;
            xrRig.transform.position = mountPoint.position - offset;
            xrRig.transform.rotation = mountPoint.rotation;

            if (driveTractor != null)
            {
                driveTractor.SetMounted(true, xrRig);
            }
        }
    }
}
