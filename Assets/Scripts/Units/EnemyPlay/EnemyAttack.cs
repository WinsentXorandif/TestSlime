using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : IEnemyPlay
{
    private bool IsPlay;
    private EnemyUnitPlay enemyUnit;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform unitTransform;
    private float attackRange;


    public EnemyAttack(EnemyUnitPlay enemy) 
    {
        IsPlay = false;
        enemyUnit = enemy;
        animator = enemy.GetAnimator();
        navMeshAgent = enemy.GetNavMeshAgent();
        navMeshAgent.speed = enemy.GetMoveSpeed();
        unitTransform = enemy.transform;
        attackRange = enemy.GetAttackRange();
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

        if (enemyUnit.enemyCol != null)
        {
            float distance = Vector3.Distance(enemyUnit.enemyCol.transform.position, unitTransform.position);
            if (distance > attackRange)
            {
                return EnemyState.Stay;
            }
            unitTransform.LookAt(enemyUnit.enemyCol.transform.position);
            animator.Play("Attack");
            return EnemyState.Attack;
        }
        return EnemyState.Stay;
    }
}
