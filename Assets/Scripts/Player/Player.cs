using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;

    PlayerMovement playerMovement;

    private GameMaster gameMaster;

    private bool invicible;
    public float invicibilityTime = 3f;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>(); // Returns GameMaster object based on tag

        playerMovement = GetComponent<PlayerMovement>();

        transform.position = gameMaster.lastCheckpointPos; // Update player position to GameMaster's last checkpoint
        invicible = false; // Player can lose a life
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes")) // If player collides with spikes
        {
            if (!invicible) // If player can be damaged by spikes
            {
                TakeDamage();
            }
            else // If player falls into spikes while incivible
            {
                Respawn();
            }
            
        }
        else if (other.gameObject.CompareTag("Ramen")) // If player collides with ramen
        {
            Destroy(other.gameObject); // Remove ramen from scene

            AddHealth();
        }
    }

    public void TakeDamage()
    {
        if (!invicible) // If player can be attacked
        {
            GameMaster.health -= 1; // Deduct one heart from their health

            FindObjectOfType<AudioManager>().Play("Death");

            StartCoroutine(Death()); // Player dies and respawns
            StartCoroutine(Invicible()); // Player will be temporarily invincible
        }
    }

    public void AddHealth()
    {
        if (GameMaster.health == 3) // If player health is full
        {
            GameMaster.currencyAmount++; // Increase their currency by 1
        }

        GameMaster.health += 1; // Else replenish one of their hearts
    }

    IEnumerator Death()
    {
        anim.SetBool("Death", true); // Play death animation
        playerMovement.enabled = false; // Disable player movement so that player cannot move when in dead state

        yield return new WaitForSeconds(1); // Wait for one second
        anim.SetBool("Death", false); // Stop death animation

        Respawn();
        playerMovement.enabled = true; //Enable player movement 
    }

    IEnumerator Invicible()
    {
        invicible = true;

        yield return new WaitForSeconds(invicibilityTime); // Invicible for 3 seconds

        invicible = false; // Player can lose health
    }

    public void Respawn() // Create a public method for respawning player
    {
        transform.position = gameMaster.lastCheckpointPos; // Change the transform.position of player to the position of the last checkpoint
    }
}
