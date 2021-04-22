using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNinja : Entity // Inherit from Entity.cs
{
    public SoundNinja_IdleState idleState { get; private set; }
    public SoundNinja_MoveState moveState { get; private set; }
    public SoundNinja_PlayerDetected playerDetectedState { get; private set; }
    public SoundNinja_ChargeState chargeState { get; private set; }
    public SoundNinja_LookForPlayerState lookForPlayerState { get; private set; }
    public SoundNinja_MeleeAttackState meleeAttackState { get; private set; }
    public SoundNinja_StunState stunState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_StunState stunStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();

        // constructors
        moveState = new SoundNinja_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new SoundNinja_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new SoundNinja_PlayerDetected(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new SoundNinja_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new SoundNinja_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new SoundNinja_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        stunState = new SoundNinja_StunState(this, stateMachine, "stun", stunStateData, this);

        stateMachine.Initialize(moveState); // Game will start with enemy in its move state
    }

    public override void OnDrawGizmos() // Overrides OnDrawGizmos in Entity.cs
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }

    public override void Damage()
    {
        base.Damage();

        if (isStunned && stateMachine.currentState != stunState) // If enemy is stunned and not in stun state
        {
            stateMachine.ChangeState(stunState); // Change state to stun state
        }
    }
}
