using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField]
    private GamePlayData playData;
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private Transform enemyPos;

    //private List<EnemyBandit> enemyList = new();



    public void addToList(EnemyBandit element) 
    {
        //enemyList.Add(element);

    }


    void Start()
    {
       // coinsPool = new ObjectsPool<MagicBall>(projectile, transform, PROJECTILE_COUNT);
    }

    void Update()
    {
        
    }
}
