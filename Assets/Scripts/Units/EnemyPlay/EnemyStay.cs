using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStay : IEnemyPlay
{
    private bool IsPlay;
    private EnemyUnitPlay enemyUnit;
    private Animator animator;



    public EnemyStay(EnemyUnitPlay enemy) 
    {
        IsPlay = false;

        enemyUnit = enemy;
        animator = enemy.GetAnimator();
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

        if (enemyUnit.FindEnemy(enemyUnit.GetEnemyLayer())) 
        {
            return EnemyState.Move;
        }

        animator.Play("Idle");

        return EnemyState.Stay;
    }
}
