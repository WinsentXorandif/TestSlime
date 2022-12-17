using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroMove : IHeroPlay
{
    private bool IsPlay;
    private HeroUnitPlay heroUnit;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform unitTransform;
    private float attackRange;


    public HeroMove(HeroUnitPlay hero) 
    {
        IsPlay = false;
        heroUnit = hero;
        animator = hero.GetAnimator();
        navMeshAgent = hero.GetNavMeshAgent();
        navMeshAgent.speed = hero.GetMoveSpeed();
        unitTransform = hero.transform;
        attackRange = hero.GetAttackRange();

    }

    public void BeginPlay()
    {
        navMeshAgent.enabled = true;
        navMeshAgent.destination = new Vector3(20f, 0f, 0f);
        if (heroUnit.enemyCol != null)
        {
            navMeshAgent.destination = heroUnit.moveTargetPos;
        }
        IsPlay = true;
    }

    public void EndPlay()
    {
        IsPlay = false;

    }

    public HeroState Play()
    {
        if (!IsPlay) return HeroState.None;

        animator.Play("Walk");

        if (heroUnit.FindEnemy(heroUnit.GetEnemyLayer()))
        {
            float distance = Vector3.Distance(heroUnit.moveTargetPos, unitTransform.position);
            if (distance < attackRange)
            {
                navMeshAgent.enabled = false;
                return HeroState.Attack;
            }
        }

        return HeroState.Move;
    }
}
