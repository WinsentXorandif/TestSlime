using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStay : IEnemyPlay
{
    public void BeginPlay()
    {

    }

    public void EndPlay()
    {

    }

    public EnemyState Play()
    {
        return EnemyState.Stay;
    }
}
