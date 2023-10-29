using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioClip[] music;
    [SerializeField] private AudioClip[] clips;

    [SerializeField] private float musicQue;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        musicQue = musicAudioSource.time;
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }

    public void PlayMusic(int index)
    {
        musicAudioSource.clip = music[index];
        musicAudioSource.time = musicQue;
        musicAudioSource.Play();
    }
}
