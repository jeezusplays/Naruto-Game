using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gameMaster;

    public GameObject checkpointParticles;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>(); // Returns GameMaster object based on tag
    }

    void OnTriggerEnter2D(Collider2D other) // Called when player collides with checkpoint
    {
        if (other.CompareTag("Player")) // Checks that player was the one that collided with the checkpoint
        {
            gameMaster.lastCheckpointPos = transform.position; // Updates GM last checkpoint position to current position
            Instantiate(checkpointParticles, transform.position, transform.rotation);
        }
    }
}
