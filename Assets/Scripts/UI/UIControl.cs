using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    [SerializeField]
    private HeroMagic player;




    public void OnButtonHealing() 
    {
        Debug.Log("OnButtonHealing() ");
    }

    public void OnButtonHP()
    {
        Debug.Log("OnButtonHP() ");
    }

    public void OnButtonAttack()
    {
        Debug.Log("OnButtonAttack() ");

    }


}
