using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public TextMeshProUGUI countdownText;

    public int countdownTime;

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); // Find Player gameObject and get PlayerMovement script

        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {   
        while (countdownTime > 0) 
        {
            playerMovement.enabled = false; // Disable player movement
            countdownText.text = countdownTime.ToString(); // Update countdown text

            yield return new WaitForSeconds(1); // Wait for 1 second

            countdownTime--; // Decrement countdown time by 1;
        }

        countdownText.text = "GO!"; // When countdown time is 0, show GO text

        // Begin game
        playerMovement.enabled = true; // Enable player movement

        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds

        countdownText.gameObject.SetActive(false); // Hide countdown text
    }
}
