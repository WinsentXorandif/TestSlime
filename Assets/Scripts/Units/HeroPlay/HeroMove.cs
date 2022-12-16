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
        navMeshAgent.destination = heroUnit.moveTargetPos;
        IsPlay = true;

    }

    public void EndPlay()
    {
        IsPlay = false;

    }

    public HeroState Play()
    {
        if (!IsPlay) return HeroState.None;

        float distance = Vector3.Distance(navMeshAgent.destination, unitTransform.position);

        if (distance < attackRange)
        {
            navMeshAgent.enabled = false;
            return HeroState.Attack;
        }

        animator.Play("Walk");
        return HeroState.Move;
    }
}
