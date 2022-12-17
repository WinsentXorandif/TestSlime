using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : IEnemyPlay
{
    private bool IsPlay;
    private EnemyUnitPlay enemyUnit;

    private Animator animator;
    private Transform unitTransform;
    private float attackRange;


    public EnemyMove(EnemyUnitPlay enemy) 
    {
        IsPlay = false;
        enemyUnit = enemy;
        animator = enemyUnit.GetAnimator();
        unitTransform = enemyUnit.transform;
        attackRange = enemyUnit.GetAttackRange();
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

        enemyUnit.FindEnemy(enemyUnit.GetEnemyLayer()); 

        animator.Play("Walk");
        if (enemyUnit.enemyCol != null)
        {
            float distance = Vector3.Distance(enemyUnit.moveTargetPos, unitTransform.position);

            unitTransform.LookAt(enemyUnit.moveTargetPos);
            unitTransform.Translate(Vector3.forward * enemyUnit.GetMoveSpeed() * Time.deltaTime);

            if (distance < attackRange)
            {
                return EnemyState.Attack;
            }
            return EnemyState.Move;
        }
        unitTransform.eulerAngles = new Vector3(0f, -90f, 0f);
        unitTransform.Translate(Vector3.forward * enemyUnit.GetMoveSpeed() * Time.deltaTime);

        return EnemyState.Move;
    }
}
