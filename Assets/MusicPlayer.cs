using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private XRLockSocketInteractor socket;
    
    private AudioSource audioSource;

    private void Start()
    {
        if (!socket)
            socket = GetComponent<XRLockSocketInteractor>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        var vinyl = socket.GetOldestInteractableSelected().transform.GetComponent<VinylData>();
        audioSource.clip = vinyl.audioClip;
        audioSource.Play();
        Debug.Log(vinyl.audioClip);
    }
    
    public void StopMusic() => audioSource.Stop();
}
