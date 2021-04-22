using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public Vector2 lastCheckpointPos; // Set last checkpoint position

    public Text currencyText;
    public GameObject heart1, heart2, heart3;

    public static int currencyAmount;
    public static int health;

    void Start()
    {
        // Currrency
        currencyAmount = 0;

        // Lives
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }

    void Update()
    {
        currencyText.text = currencyAmount.ToString();

        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3: // Case where player has not taken damage
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2: // Case where player took one damage
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1: // Case where player took two damage
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0: // Case where player lost all lives
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);

                StartCoroutine(Failed()); // Start game over
                break;
        }
    }    

    IEnumerator Failed()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Failure");
    }
}
