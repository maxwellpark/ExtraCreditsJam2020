using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    float clipLength;
    float timer; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clipLength = audioSource.clip.length;
        timer = clipLength; 
    }

    void Update()
    {
        if (audioSource.loop)
        {
            PreventLoopClash(); 
        }
    }

    void PreventLoopClash()
    {
        if (timer <= 0f)
        {
            audioSource.Stop();
            audioSource.Play();
            timer = clipLength;
        }
        timer--; 
    }
}
