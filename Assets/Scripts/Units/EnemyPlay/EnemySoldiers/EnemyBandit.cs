using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBandit : EnemyUnitPlay
{

    protected override void OnAttack()
    {
        if (enemyCol != null)
        {
            if (enemyCol.TryGetComponent<Units>(out var unit))
            {
                unit.OnDamage(attack);
                //Debug.Log("OnDamage(attack)!!!");
            }
        }
    }

    void Update()
    {

        OnUpdate();
        
    }
}
