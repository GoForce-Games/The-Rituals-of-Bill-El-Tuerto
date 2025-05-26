using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerTrigger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Nombre de la escena a cargar

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra al trigger tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}