using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroMove : IHeroPlay
{
    private bool IsPlay;
    private HeroUnitPlay heroUnit;

    private Animator animator;
    private Transform unitTransform;
    private float attackRange;


    public HeroMove(HeroUnitPlay hero) 
    {
        IsPlay = false;
        heroUnit = hero;
        animator = hero.GetAnimator();
        unitTransform = hero.transform;
        attackRange = hero.GetAttackRange();

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

        animator.Play("Walk");

        if (heroUnit.FindEnemy(heroUnit.GetEnemyLayer()))
        {
            unitTransform.LookAt(heroUnit.moveTargetPos);
            float distance = Vector3.Distance(heroUnit.moveTargetPos, unitTransform.position);
            if (distance < attackRange)
            {
                return HeroState.Attack;
            }
        }
        unitTransform.eulerAngles = new Vector3(0f,90f,0f);
        unitTransform.Translate(Vector3.forward * heroUnit.GetMoveSpeed() *Time.deltaTime);

        return HeroState.Move;
    }
}
