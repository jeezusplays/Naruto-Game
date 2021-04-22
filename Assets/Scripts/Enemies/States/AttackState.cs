using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private SoundNinja enemy;
    protected Transform attackPosition;

    protected bool isAnimationFinished;
    protected bool isPlayerInMinAgroRange;

    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public override void Enter() // When player enters attack state and attacks, calls TrigggerAttack() and FinishAttack()
    {
        base.Enter();

        entity.atsm.attackState = this;
        isAnimationFinished = false;
        entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void TriggerAttack() // All attack states have this function
    {
        // Start of attack
    }

    public virtual void FinishAttack() // All attack states have this function
    {
        // End of attack
        isAnimationFinished = true;
    }
}
