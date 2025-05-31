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
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        var vinyl = socket.GetOldestInteractableSelected().transform.GetComponent<VinylNumber>();
        audioSource.clip = vinyl.audio;
        audioSource.Play();
    }
    
    public void StopMusic() => audioSource.Stop();
}
