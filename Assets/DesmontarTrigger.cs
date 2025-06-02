using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DesmontarTrigger : MonoBehaviour
{
    public MountAndDriveTractor tractorScript;

    private void Start()
    {
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelect);
        }
    }

    private void OnDestroy()
    {
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelect);
        }
    }

    private void OnSelect(SelectEnterEventArgs args)
    {
        if (tractorScript != null)
        {
            tractorScript.DismountFromOutside(); 
        }
    }
}