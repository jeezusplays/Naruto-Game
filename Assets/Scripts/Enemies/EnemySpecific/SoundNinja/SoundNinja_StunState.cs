using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNinja_StunState : StunState
{
    private SoundNinja enemy;

    public SoundNinja_StunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData, SoundNinja enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        if (isStunTimeOver) // If enemy is no longer stunned
        {
            if(performCloseRangeAction) // And is able to perform melee attack
            {
                stateMachine.ChangeState(enemy.meleeAttackState); // Change state to melee attack state
            }
            else if (isPlayerInMinAgroRange) // Else if player is in enemy's minimum agro range
            {
                stateMachine.ChangeState(enemy.chargeState); // Change state to charge state
            }
            else
            {
                enemy.lookForPlayerState.SetTurnImmediately(true); 
                stateMachine.ChangeState(enemy.lookForPlayerState); // Change to look for player state
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
