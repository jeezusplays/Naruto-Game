using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endpoint : MonoBehaviour
{
    public TimeMaster timeMaster; // Reference TimerMaster.cs to check if time is over

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // If player collided with endpoint,
        {            
            if (!timeMaster.isTimeOver) // Check that time is not over
            {
                //Debug.Log("Currency: " + GameMaster.currencyAmount);
                
                PlayerPrefs.SetInt("currency", (PlayerPrefs.GetInt("currency", 0) + GameMaster.currencyAmount)); // Update player currency
                PlayerPrefs.Save(); // Save player currency
                
                SceneManager.LoadScene("Victory"); // Change scene                
            }

        }        
    }
}
