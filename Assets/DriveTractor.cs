using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class DriveTractor : MonoBehaviour
{
    public bool isMounted = false; // Se activa cuando el jugador está montado
    public float speed = 2f;
    public float turnSpeed = 45f;

    private XROrigin xrOrigin;
    private Vector2 moveInput;

    private void Update()
    {
        if (isMounted)
        {
            // Movimiento hacia adelante/atrás
            transform.Translate(Vector3.forward * moveInput.y * speed * Time.deltaTime);
            // Rotación izquierda/derecha
            transform.Rotate(Vector3.up, moveInput.x * turnSpeed * Time.deltaTime);
        }
    }

    public void SetMounted(bool mounted, XROrigin origin = null)
    {
        isMounted = mounted;
        xrOrigin = origin;
    }

    // Método llamado desde otro script para actualizar el input
    public void UpdateInput(Vector2 input)
    {
        moveInput = input;
    }
}
