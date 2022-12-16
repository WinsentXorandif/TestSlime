using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : IHeroPlay
{
    public void BeginPlay()
    {

    }

    public void EndPlay()
    {

    }

    public HeroState Play()
    {
        return HeroState.Move;
    }
}
