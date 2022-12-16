using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HeroStay : IHeroPlay
{
    private bool IsPlay;
    private HeroUnitPlay heroUnit;

    public HeroStay(HeroUnitPlay hero) 
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

        return HeroState.Stay;
    }

}
