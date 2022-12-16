using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : IEnemyPlay
{
    public void BeginPlay()
    {

    }

    public void EndPlay()
    {

    }

    public EnemyState Play()
    {
        return EnemyState.Attack;
    }
}
