using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNinja_IdleState : IdleState // Inherit IdleState.cs
{
    private SoundNinja enemy;

    public SoundNinja_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, SoundNinja enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState); // If RayCast has detected player in MinAgroRange, transition to PlayerDetectedState
        }

        else if (isIdleTimeOver) // If true, transition to move
        {
            stateMachine.ChangeState(enemy.moveState);
        }    
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
