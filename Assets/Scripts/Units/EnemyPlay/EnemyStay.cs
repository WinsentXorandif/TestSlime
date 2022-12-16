using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStay : IEnemyPlay
{
    private bool IsPlay;
    private EnemyUnitPlay enemyUnit;

    public EnemyStay(EnemyUnitPlay enemy) 
    {
        enemyUnit = enemy;
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

        return EnemyState.Stay;
    }
}
