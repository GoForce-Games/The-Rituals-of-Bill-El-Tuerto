using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class muerte : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string sceneToLoad; // Nombre de la escena a cargar

    public void LoadSceneMain()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
