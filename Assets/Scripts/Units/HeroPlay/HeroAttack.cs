using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroAttack : IHeroPlay
{
    private bool IsPlay;
    private HeroUnitPlay heroUnit;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform unitTransform;
    private float attackRange;


    public HeroAttack(HeroUnitPlay hero) 
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
        IsPlay = true;

    }

    public void EndPlay()
    {
        IsPlay = false;

    }

    public HeroState Play()
    {
        if (!IsPlay) return HeroState.None;
        if (heroUnit.enemyCol != null)
        {
            float distance = Vector3.Distance(heroUnit.enemyCol.transform.position, unitTransform.position);
            if (distance > attackRange)
            {
                return HeroState.Stay;
            }
            unitTransform.LookAt(heroUnit.enemyCol.transform.position);
            animator.Play("Cast");
            return HeroState.Attack;
        }
        return HeroState.Stay;
    }
}
