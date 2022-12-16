using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : IHeroPlay
{
    private bool IsPlay;

    private HeroUnitPlay heroUnit;

    public HeroAttack(HeroUnitPlay hero) 
    {
        heroUnit = hero;

    }
    public void BeginPlay()
    {
        IsPlay = true;

    }

    public void EndPlay()
    {
        IsPlay = false;

    }

    public HeroState Play()
    {
        if (!IsPlay) return HeroState.None;

        return HeroState.Attack;
    }
}
