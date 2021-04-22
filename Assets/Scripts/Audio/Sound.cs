using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable] // Allow saving of objects and recreaion when needed, providing storage
public class Sound // For AudioManager.cs
{
    public string nameOfAudio;

    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool isLoopOn;

    [HideInInspector]
    public AudioSource source; // Do not show source in inspector
}

