using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Units : MonoBehaviour
{
    private const int MAX_ENEMYS = 5;
    private const float MAX_DISTANCE = 1000.0f;

    [SerializeField]
    private UnitData unitData;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    protected NavMeshAgent navMeshAgent;
    [SerializeField]
    protected HealthBar healthBar;

    protected Collider coll;

    protected int hitPoint;
    protected int defence;
    protected float findRange;
    protected int attack;
    protected float attackRange;
    protected float speed;
    protected LayerMask enemyLayer;
    protected GameObject projectile;

    public Collider enemyCol { get; set; }
    public Vector3 moveTargetPos { get; set; }
    public Animator GetAnimator() { return animator; }
    public NavMeshAgent GetNavMeshAgent() { return navMeshAgent; }
    public float GetRange() { return findRange; }
    public float GetAttackRange() { return attackRange; }
    public float GetMoveSpeed() { return speed; }
    public LayerMask GetEnemyLayer() { return enemyLayer; }

    protected void InitUnitData()
    {
        coll = GetComponent<Collider>();
        hitPoint = unitData.GetHitPoint();
        healthBar.SetMaxHealth(hitPoint);
        defence = unitData.GetDefence();
        findRange = unitData.GetFindRange();
        attackRange = unitData.GetAttackRange();
        attack = unitData.GetAttack();
        speed = unitData.GetMoveSpeed();
        enemyLayer = unitData.GetEnemyLayer();
        projectile = unitData.GetProjectile();
    }

    protected virtual void OnAttack() { }
    public virtual void OnDamage(int damage) { }
    protected virtual void OnDie() { }


    public bool FindEnemy(LayerMask enemyLayer)
    {
        float minDistance = MAX_DISTANCE;

        Collider[] hitColliders = new Collider[MAX_ENEMYS];
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, findRange, hitColliders, enemyLayer);

        if (numColliders == 0) return false;

        int nearestEnemy = 0;

        for (int i = 0; i < numColliders; i++)
        {
            float distance = Vector3.Distance(hitColliders[i].transform.position, transform.position);
            if (distance < minDistance) { minDistance = distance; nearestEnemy = i; }
        }
        enemyCol = hitColliders[nearestEnemy];
        moveTargetPos = enemyCol.transform.position;

        Debug.Log($"enemyCol = {enemyCol.name} moveTargetPos = {moveTargetPos}");

        return true;

        /*
        if (minDistance < attackRange)
        {
            navMeshAgent.enabled = false;
            return true; //HeroState.Attack;
        }
        */

        //return false;

        //moveTargetPos = enemyCol.transform.position;
        //navMeshAgent.enabled = true;
        //navMeshAgent.destination = moveTargetPos;
        //return HeroState.Move;

    }



}
