using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndActivateOnTrigger : MonoBehaviour
{
    
    public GameObject music;

    [Header("Movimiento")]
    public Transform targetPosition; // El transform al que se moverá el objeto
    public GameObject objectToMove;  // El objeto que se moverá (la bañera)

    [Header("Activación")]
    public GameObject objectToActivate; // El objeto que se activará

    [Header("Control de Contacto")]
    public Rigidbody otherRigidbody; // La bañera (el otro rigidbody)
    
    private bool hasActivated = false; // Para evitar activaciones múltiples

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entró es la bañera y no hemos activado aún
        if (!hasActivated && other.GetComponent<Rigidbody>() == otherRigidbody)
        {
            ActivateObjects();
            hasActivated = true;
        }
    }

    // También detectar colisiones físicas (no solo triggers)
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisionó es la bañera
        if (!hasActivated && collision.rigidbody == otherRigidbody)
        {
            ActivateObjects();
            hasActivated = true;
        }
    }

    private void ActivateObjects()
    {
        // Mover el objeto
        if (objectToMove != null && targetPosition != null)
        {
            objectToMove.transform.position = targetPosition.position;
        }

        // Activar el objeto
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
            music.SetActive(false);
        }
        
        Debug.Log("¡Objetos activados!");
    }

    // Método para resetear si necesitas reactivar
    public void ResetActivation()
    {
        hasActivated = false;
    }
}