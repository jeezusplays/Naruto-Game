using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNinja_PlayerDetected : PlayerDetectedState // Inherit from PlayerDetectedState.cs
{
    public SoundNinja enemy;
    public SoundNinja_PlayerDetected(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, SoundNinja enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if (performCloseRangeAction) // If enemy is within attack range
        {
            stateMachine.ChangeState(enemy.meleeAttackState); // Attack player
        }
        else if (performLongRangeAction)  // Else if player is still in minimum agro range
        {
            stateMachine.ChangeState(enemy.chargeState); // Charge at player
        }
        else if (!isPlayerInMaxAgroRange) // Else if player is no longer in maximum agro range
        {
            stateMachine.ChangeState(enemy.lookForPlayerState); // Look for player
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
