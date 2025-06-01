using UnityEngine;
using UnityEngine.InputSystem;

public class TractorInputRelay : MonoBehaviour
{
    public DriveTractor tractor;
    public InputActionReference moveAction; // <- asignar desde el inspector

    void Update()
    {
        if (tractor != null && tractor.isMounted)
        {
            Vector2 input = moveAction.action.ReadValue<Vector2>();
            tractor.UpdateInput(input);
        }
    }
}
