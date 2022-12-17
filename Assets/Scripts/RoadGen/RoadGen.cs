using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoadGen : MonoBehaviour
{
    [SerializeField]
    private GameObject groung;
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Transform enemyPoint;

    private TriggerG activeGen;

    private int count;
    private float offsetX;
    private Vector3 newPos;

    private List<GameObject> groundList = new(); 


    private void Start()
    {
        count = 0;

        offsetX = groung.transform.localScale.x;
        activeGen = groung.GetComponentInChildren<TriggerG>();
        activeGen.InitGen(this);
    }

    public void CreateNewGround() 
    {

        if (groundList.Count > 2)
        {
            Destroy(groundList[groundList.Count - 2]);
        }

        count++;
        newPos = groung.transform.position;
        newPos.x += offsetX*count;

        GameObject newGr = Instantiate(groung, newPos, groung.transform.rotation);

        activeGen = newGr.GetComponentInChildren<TriggerG>();
        activeGen.InitGen(this);

        groundList.Add(newGr);

        enemyPoint = activeGen.enemyPoit;


        int ran = Random.Range(3, 7);
        CreateEnemy(ran);

    }


    private void CreateEnemy(int con)
    {
        Debug.Log($"con = {con}");
        Vector3 newpos = enemyPoint.position;
        for (int i = 0; i < con; i++) { 
            newpos.x += Random.Range(1, 4);
            newpos.z = Random.Range(-1, 1);

            GameObject en = Instantiate(enemy, newpos, enemyPoint.rotation);
            en.GetComponent<EnemyUnitPlay>().UpDateHP(count, count);
            newpos = en.transform.position;
        }
    }

}
