using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; // Array for the sounds the game has

    public static AudioManager audioManager;

    void Awake()
    {
        if (audioManager == null) // If an instance of AudioManager does not exist
        {
            audioManager = this; // Make this the instance
        }            
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>(); 
            s.source.clip = s.audioClip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.isLoopOn;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.nameOfAudio == name);

        if (s == null) // If audio does not exist, return
            return;

        s.source.Play();
    }
}
