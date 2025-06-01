using UnityEngine;

public class CollisionActivator : MonoBehaviour
{
    public GameObject objectToActivate; // Objeto C que se activará
    public Rigidbody otherRb;

    private void OnCollisionEnter(Collision collision)
    {
        otherRb = collision.rigidbody;

        if (otherRb != null)
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No se ha asignado el objeto a activar.");
            }
        }
    }
}
