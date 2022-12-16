using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : IHeroPlay
{
    private bool IsPlay;

    private HeroUnitPlay heroUnit;

    public HeroMove(HeroUnitPlay hero) 
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

        return HeroState.Move;
    }
}
