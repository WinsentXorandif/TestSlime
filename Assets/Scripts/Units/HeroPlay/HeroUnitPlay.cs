using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HeroUnitPlay : Units
{
    public Action<HeroUnitPlay> OnUnitDie;
   // public Action OnActivateUnit;

    private const float DESTROY_TIME = 5f;
    //private const int MAX_ENEMYS = 5;
    //private const float MAX_DISTANCE = 1000.0f;

    protected Dictionary<HeroState, IHeroPlay> unitPlayDict;
    protected IHeroPlay iUnitPlayCurrent;
    protected HeroState unitStateCurrent;

    public bool ActivateUnit { get; set; }

    private void InitPlayDict()
    {
        unitPlayDict = new Dictionary<HeroState, IHeroPlay>
        {
            { HeroState.None, new HeroNone() },
            { HeroState.Stay, new HeroStay(this)},
            { HeroState.Move, new HeroMove(this)},
            { HeroState.Attack, new HeroAttack(this)}
        };
    }

    private void Awake()
    {
        InitUnitData();
        InitPlayDict();
        InitPlayStart();
    }

    private void InitPlayStart()
    {
        //ActivateUnit = false;
        //healthBar.SetMaxHealth(hitPoint);

        unitStateCurrent = HeroState.Stay;
        iUnitPlayCurrent = unitPlayDict[unitStateCurrent];
        iUnitPlayCurrent.BeginPlay();
    }

    public HeroState SetNewUnitPlay(HeroState newUnitPlay)
    {
        iUnitPlayCurrent?.EndPlay();

        unitStateCurrent = newUnitPlay;
        iUnitPlayCurrent = unitPlayDict[newUnitPlay];
        iUnitPlayCurrent.BeginPlay();
        return unitStateCurrent;
    }

    public override void OnDamage(int damage)
    {
        hitPoint -= Mathf.Abs(damage - defence);
        healthBar.SetHealth(hitPoint);
        if (hitPoint <= 0)
        {
            OnDie();
        }
    }

    protected override void OnDie()
    {
        navMeshAgent.enabled = false;
        Destroy(healthBar.gameObject);
        Destroy(coll);
        Destroy(gameObject, DESTROY_TIME);
        //SetNewUnitPlay(UnitStates.Die);

    }

    //protected virtual void OnAttack() { }

    //private void OnDestroy()
    //{
    //    OnUnitDie?.Invoke(this);  //????????????????
    //}

    public void OnUpdate()
    {
        HeroState newUnitPlay = iUnitPlayCurrent.Play();

        if (newUnitPlay != unitStateCurrent)
        {
            SetNewUnitPlay(newUnitPlay);
        }
    }



}
