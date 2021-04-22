using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour // Seamless music
{
    AudioSource audioSource;

    Scene currentScene;

    string currentSceneName;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        currentScene = SceneManager.GetActiveScene(); // Get the current scene
        currentSceneName = currentScene.name; // Set name of current scene to currentSceneName

        //Debug.Log(currentSceneName);

        if (currentSceneName == "Naruto")
        {
            audioSource.mute = true; // Mute audio if scene is "Naruto"
        }

    }
    void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music"); // Check how many objects are tagged by Music tag

        if (music.Length > 1) // If there is more than one object
            Destroy(this.gameObject); // Destroy that object

        DontDestroyOnLoad(this.gameObject); // Else do not destroy object
    }
}
