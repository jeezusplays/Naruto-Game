using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    public Vector2 spawnPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        rb.velocity = Vector3.zero;
        //Debug.Log("Enemy died");
       
        anim.SetBool("isDead", true); // Play death animation

        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1); // Wait for one second

        FindObjectOfType<AudioManager>().Play("Death"); 

        // Disable enemy
        gameObject.SetActive(false);
        this.enabled = false;

        GameMaster.currencyAmount++; // Add one currency
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes")) // If enemy collides with spikes, bring them back to their original spawn position
        {
            transform.position = spawnPosition; 
        }
    }
}
