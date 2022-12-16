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


    public HeroStay(HeroUnitPlay hero) 
    {
        IsPlay = false;

        heroUnit = hero;
        animator = hero.GetAnimator();
        navMeshAgent = hero.GetNavMeshAgent();

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

        return HeroState.Stay;
    }

}
