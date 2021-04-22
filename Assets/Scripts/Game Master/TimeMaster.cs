using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro

public class TimeMaster : MonoBehaviour
{
    [SerializeField] float startTime = 60f;
    [SerializeField] TextMeshProUGUI timerText;
    
    public bool isTimeOver;
    
    float timer = 0f;

    void Start()
    {
        isTimeOver = false;

        StartCoroutine(Timer());
    }

    void Update()
    {
        if (isTimeOver) // Time is over
        {
            SceneManager.LoadScene("Failure"); // Player fails level
        }
    }

    private IEnumerator Timer()
    {
        timer = startTime;

        do
        {
            timer -= Time.deltaTime; // Decrement number of seconds by time

            formatText();

            if (timer < 0) // If timer is less than 0, game should be over
            {
                isTimeOver = true; // Allow game over check
            }

            yield return null;
        }
        while (timer > 0); // While timer is more than 0, do nothing
    }

    private void formatText() // Format how text looks during gameplay
    {
        int seconds = Convert.ToInt32(timer);

        timerText.text = ""; // By default, timer text should be empty
        if (seconds > 0) { timerText.text += seconds + "s "; } // If seconds is more than 0, update timer text
    }
}
