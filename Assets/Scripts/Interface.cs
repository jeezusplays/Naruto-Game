using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public void PlayGame() // Create a public method to transition to actual game
    {
        // Use SceneManager to load scene: Naruto
        SceneManager.LoadScene("Naruto");
    }

    public void HowToPlay() // Create a public method to transition to scene with game controls
    {
        // Use SceneManager to load scene: Instructions
        SceneManager.LoadScene("Instructions");
    }

    public void BackToMenu() // Create a public method to transition to main menu 
    {
        // Use SceneManager to load scene: MainMenu
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToShop() // Create a public method to transition to shop
    {
        // Use SceneManager to load scene: Shop
        SceneManager.LoadScene("Shop");
    }

    public void QuitGame() // Create a public method to quit game
    {
        //Debug.Log("Quit");
        Application.Quit();
    }
}
