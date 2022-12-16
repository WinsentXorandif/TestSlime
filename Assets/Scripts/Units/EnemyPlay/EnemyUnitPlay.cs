using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitPlay : Units
{
    public Action<EnemyUnitPlay> OnUnitDie;

    private const float DESTROY_TIME = 5f;
    //private const int MAX_ENEMYS = 5;
    //private const float MAX_DISTANCE = 1000.0f;

    protected Dictionary<EnemyState, IEnemyPlay> enemyPlayDict;
    protected IEnemyPlay iEnemyPlayCurrent;
    protected EnemyState enemyStateCurrent;

    private void InitPlayDict()
    {
        enemyPlayDict = new Dictionary<EnemyState, IEnemyPlay>
        {
            { EnemyState.None, new EnemyNone() },
            { EnemyState.Stay, new EnemyStay(this)},
            { EnemyState.Move, new EnemyMove(this)},
            { EnemyState.Attack, new EnemyAttack(this)},
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
        //navMeshAgent.enabled = false;

        enemyStateCurrent = EnemyState.Stay;
        iEnemyPlayCurrent = enemyPlayDict[enemyStateCurrent];
        iEnemyPlayCurrent.BeginPlay();
    }


    public EnemyState SetNewUnitPlay(EnemyState newUnitPlay)
    {
        iEnemyPlayCurrent?.EndPlay();

        enemyStateCurrent = newUnitPlay;
        iEnemyPlayCurrent = enemyPlayDict[newUnitPlay];
        iEnemyPlayCurrent.BeginPlay();
        return enemyStateCurrent;
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
        //SetNewUnitPlay(EnemyUnitStates.Die);

    }

    //private void OnDestroy()
    //{
    //    OnUnitDie?.Invoke(this);
    //}


    public void OnUpdate()
    {
        EnemyState newEnemyPlay = iEnemyPlayCurrent.Play();

        Debug.Log($"newEnemyPlay = {newEnemyPlay}");

        if (newEnemyPlay != enemyStateCurrent)
        {
            SetNewUnitPlay(newEnemyPlay);
        }
    }


}
