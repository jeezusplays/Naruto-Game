using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour //Base Script for Enemies 
{
    public FiniteStateMachine stateMachine;
    public D_Entity entityData;
    public Enemy enemy;

    public int facingDirection { get; private set; } // public getter, private setter
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGameObject { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }
    public int lastDamageDirection { get; private set; }

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    private Transform groundCheck;

    private Vector2 velocityWorkspace;

    private float currentHealth;
    private float currentStunResistance;
    private float lastDamageTime;

    protected bool isStunned;

    public virtual void Start()
    {
        facingDirection = -1; // By default, enemies are facing left, hence we use -1
        currentHealth = entityData.maxHealth;
        currentStunResistance = entityData.stunResistance;

        aliveGameObject = transform.Find("Alive").gameObject;

        rb = aliveGameObject.GetComponent<Rigidbody2D>();
        anim = aliveGameObject.GetComponent<Animator>();
        atsm = aliveGameObject.GetComponent<AnimationToStateMachine>();
        enemy = aliveGameObject.GetComponent<Enemy>();

        stateMachine = new FiniteStateMachine(); // Every entity will have its own state machine that is an instance of FiniteStateMachine
    }

    public virtual void Update()
    {
        // Everytime this function gets called, calls the function in State.cs
        stateMachine.currentState.LogicUpdate();

        if (Time.time >= lastDamageTime + entityData.recoveryTime)
        {
            ResetStun();
        }
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y); // Set velocity of enemy
        rb.velocity = velocityWorkspace;
    }

    public virtual void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize(); // normalize the angle before using

        velocityWorkspace.Set(angle.x * velocity * direction, angle.y * velocity);
        rb.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall() // Check if enemy is facing and hitting the wall
    {
        return Physics2D.Raycast(wallCheck.position, -aliveGameObject.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckLedge() // Check if enemy is near a ledge
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckGround() // Check if enemy is grounded
    {
        return Physics2D.OverlapCircle(groundCheck.position, entityData.groundCheckRadius, entityData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, -aliveGameObject.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, -aliveGameObject.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction() // Melee Attack
    {
        return Physics2D.Raycast(playerCheck.position, -aliveGameObject.transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }

    public virtual void DamageHop(float velocity) // Enemy knockback 
    {
        velocityWorkspace.Set(rb.velocity.x, velocity);
        rb.velocity = velocityWorkspace;
    }

    public virtual void ResetStun()
    {
        isStunned = false;
        currentStunResistance = entityData.stunResistance;
    }

    public virtual void Damage()
    {
        lastDamageTime = Time.time;
        currentHealth -= 1; // Decrement health by 1
        currentStunResistance -= 1; // Decrement stun resistance by 1

        DamageHop(entityData.damageHopSpeed);

        if (aliveGameObject.transform.position.x < 0) 
            lastDamageDirection = -1;
        else
            lastDamageDirection = 1;

        if (currentStunResistance <= 0)
        {
            isStunned = true; // Enemy is stunned
        }

        if (currentHealth <= 0)
        {
            enemy.Die(); // Enemy is dead
        }
    }

    public virtual void Flip() 
    {
        facingDirection *= -1;
        aliveGameObject.transform.Rotate(0f, 180f, 0f); // Flips enemy on the y-axis 
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
    }
}
