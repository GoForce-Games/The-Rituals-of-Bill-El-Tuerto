using UnityEngine;
using UnityEngine.Video;

public class VideoMusicController : MonoBehaviour
{
    public VideoPlayer videoPlayer;   
    public AudioSource backgroundMusic; 

    void Start()
    {
        if (videoPlayer != null)
        {
           
            videoPlayer.started += OnVideoStarted;

            
            videoPlayer.loopPointReached += OnVideoEnded;
        }
    }

    void OnVideoStarted(VideoPlayer vp)
    {
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause(); 
        }
    }

    void OnVideoEnded(VideoPlayer vp)
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play(); 
        }
    }
}