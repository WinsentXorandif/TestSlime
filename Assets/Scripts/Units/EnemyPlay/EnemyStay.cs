using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStay : IEnemyPlay
{
    private bool IsPlay;
    private EnemyUnitPlay enemyUnit;
    private Animator animator;
    private NavMeshAgent navMeshAgent;


    public EnemyStay(EnemyUnitPlay enemy) 
    {
        IsPlay = false;

        enemyUnit = enemy;
        animator = enemy.GetAnimator();
        navMeshAgent = enemy.GetNavMeshAgent();

    }

    public void BeginPlay()
    {
        IsPlay = true;
    }

    public void EndPlay()
    {
        IsPlay = false;
    }

    public EnemyState Play()
    {
        if (!IsPlay) return EnemyState.None;

        animator.Play("Idle");

        return EnemyState.Stay;
    }
}
