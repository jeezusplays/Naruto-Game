using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    /// <summary>
    /// Script for player combat
    /// </summary>

    public Animator anim;
    public Transform attackPoint;
    
    public LayerMask enemyLayer;

    public float attackRange = 0.5f;
    public int attackDamage = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // If player click on left mouseclick button
        {
            Attack();
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack"); // Trigger animation for normal attacks

        // Detect enemies in enemy layer that arre in range of attack circle
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer); 
        
        foreach(Collider2D enemy in hitEnemies)
        {
            // Damage enemies / enemy
            FindObjectOfType<AudioManager>().Play("Punch");
            enemy.transform.parent.SendMessage("Damage"); // calls for Damage() in every monobehaviour script
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange); // Draw sphere to show attack range and position
    }
}
