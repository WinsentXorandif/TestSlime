using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerG : MonoBehaviour
{

    private RoadGen roadGen;
    public Transform enemyPoit;

    public void InitGen(RoadGen roadGenerator) 
    {
        roadGen = roadGenerator;
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.transform.GetComponent<HeroMagic>())
       {
            Debug.Log("Create new Ground!!!!!!!!");
            roadGen.CreateNewGround();
       }
    }


}
