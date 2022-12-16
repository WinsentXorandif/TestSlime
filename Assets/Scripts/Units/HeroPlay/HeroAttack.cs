using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : IHeroPlay
{
    public void BeginPlay()
    {

    }

    public void EndPlay()
    {

    }

    public HeroState Play()
    {
        return HeroState.Attack;
    }
}
