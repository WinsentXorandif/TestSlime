using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : IEnemyPlay
{
    private bool IsPlay;
    private EnemyUnitPlay enemyUnit;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform unitTransform;


    public EnemyMove(EnemyUnitPlay enemy) 
    {
        IsPlay = false;
        enemyUnit = enemy;
        animator = enemyUnit.GetAnimator();
        navMeshAgent = enemyUnit.GetNavMeshAgent();
        navMeshAgent.speed = enemyUnit.GetMoveSpeed();
        unitTransform = enemyUnit.transform;
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

        animator.Play("Walk");
        float distance = Vector3.Distance(navMeshAgent.destination, unitTransform.position);

        if (distance < 1.0f)
        {
            Debug.Log($"Enemy prishel");
            navMeshAgent.enabled = false;
            return EnemyState.Stay;
        }

        return EnemyState.Move;
    }
}
