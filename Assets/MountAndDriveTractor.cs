using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class MountAndDriveTractor : MonoBehaviour
{
    [Header("References")]
    public XROrigin xrRig;
    public Transform mountPoint;
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable; 

    private bool isMounted = false;

    void Start()
    {
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnInteract);
        }
    }

    void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnInteract);
        }
    }

    private void OnInteract(SelectEnterEventArgs args)
    {
        // Alternar montado / desmontado
        if (!isMounted)
        {
            Mount();
        }
        else
        {
            Dismount();
        }
    }

    void Mount()
    {
        if (xrRig != null && mountPoint != null)
        {
            Transform cameraTransform = xrRig.Camera.transform;
            Vector3 headToRigOffset = cameraTransform.position - xrRig.transform.position;
            Vector3 newRigPosition = mountPoint.position - headToRigOffset;

            xrRig.transform.position = newRigPosition;
            xrRig.transform.rotation = Quaternion.Euler(0, mountPoint.eulerAngles.y, 0);

            isMounted = true;
        }
    }


    void Dismount()
    {
        isMounted = false;
    }

    void Update()
    {
        if (isMounted && xrRig != null)
        {
            // Mueve el tractor para que siga al XR Rig (horizontalmente)
            Vector3 offset = xrRig.Camera.transform.position - xrRig.transform.position;
            Vector3 targetPosition = xrRig.transform.position + offset;
            targetPosition.y = transform.position.y;

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
            transform.rotation = Quaternion.Euler(0, xrRig.Camera.transform.eulerAngles.y, 0);
        }
    }
}
