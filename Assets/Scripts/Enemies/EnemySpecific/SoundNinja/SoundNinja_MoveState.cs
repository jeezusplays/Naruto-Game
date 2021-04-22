using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNinja_MoveState : MoveState // Inherit MoveState.cs
{
    private SoundNinja enemy;

    public SoundNinja_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, SoundNinja enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        else if (isDetectingWall || !isDetectedLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState); // If enemy hits wall or detects a ledge, transition to IdleState
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
