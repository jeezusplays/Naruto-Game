using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNinja_MeleeAttackState : MeleeAttackState
{
    private SoundNinja enemy;

    public SoundNinja_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, SoundNinja enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished) // if attack animation is done
        {
            if (isPlayerInMinAgroRange) // check if enemy is still in min agro range
            {
                // if yes, change state to player detected state
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                // else change state to look for player state
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
