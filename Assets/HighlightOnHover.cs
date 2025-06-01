using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using cakeslice; // Asegúrate que el namespace es correcto

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable))]
public class HighlightOnHover : MonoBehaviour
{
    private Outline outline;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    void Awake()
    {
        outline = GetComponent<Outline>();
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        if (outline != null)
            outline.enabled = false;

        grabInteractable.hoverEntered.AddListener(OnHoverEnter);
        grabInteractable.hoverExited.AddListener(OnHoverExit);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (outline != null)
            outline.enabled = true;
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        if (outline != null)
            outline.enabled = false;
    }
}
