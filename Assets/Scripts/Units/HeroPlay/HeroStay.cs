using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class HeroStay : IHeroPlay
{
    private bool IsPlay;
    private HeroUnitPlay heroUnit;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform unitTransform;
    private float attackRange;



    public HeroStay(HeroUnitPlay hero) 
    {
        IsPlay = false;

        heroUnit = hero;
        animator = hero.GetAnimator();
        //navMeshAgent = hero.GetNavMeshAgent();
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
        animator.Play("Idle");
        if (heroUnit.FindEnemy(heroUnit.GetEnemyLayer()))
        {
            float distance = Vector3.Distance(heroUnit.moveTargetPos, unitTransform.position);
            if (distance < attackRange)
            {
                //navMeshAgent.enabled = false;
                return HeroState.Attack;
            }

            return HeroState.Move;
        }

        return HeroState.Move;
    }

}
