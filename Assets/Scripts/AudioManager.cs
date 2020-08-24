using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // redundant?
        audioSource.Play();

    }

    void Update()
    {
        
    }
}
