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
    private float attackRange;


    public EnemyMove(EnemyUnitPlay enemy) 
    {
        IsPlay = false;
        enemyUnit = enemy;
        animator = enemyUnit.GetAnimator();
        navMeshAgent = enemyUnit.GetNavMeshAgent();
        navMeshAgent.speed = enemyUnit.GetMoveSpeed();
        unitTransform = enemyUnit.transform;
        attackRange = enemyUnit.GetAttackRange();
    }

    public void BeginPlay()
    {
        navMeshAgent.enabled = true;
        navMeshAgent.destination = new Vector3(20f, 0f, 0f);

        if (enemyUnit.enemyCol != null)
        {
            navMeshAgent.destination = enemyUnit.moveTargetPos; 
        }
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

        if (distance < attackRange)
        {
            navMeshAgent.enabled = false;
            return EnemyState.Attack;
        }
        return EnemyState.Move;
    }
}
