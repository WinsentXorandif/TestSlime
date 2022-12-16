using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNone : IEnemyPlay
{
    public void BeginPlay()
    {

    }

    public void EndPlay()
    {

    }

    public EnemyState Play()
    {
        return EnemyState.None;
    }
}
