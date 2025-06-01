using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndSceneLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneToLoad;

    void Start()
    {
        // Asegúrate de que el VideoPlayer está asignado
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();

        // Suscribe al evento que se lanza al terminar el video
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
