using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIControl : MonoBehaviour
{
    [SerializeField]
    private HeroMagic player;

    [SerializeField]
    private TextMeshProUGUI coins;

    private int coinsCount;

    private ObjectsPool<Coins> coinsPool;

    [SerializeField]
    private Coins coinsPrefab;

    public Transform coinsImage;


    private void Start()
    {
        coinsCount = 0;
        coins.text = string.Empty;
        coinsPool = new ObjectsPool<Coins>(coinsPrefab, transform, 40);
    }

    public void CreateCoins(int count, Transform pos) 
    {
        Debug.Log($"CreateCoins = {count}");
        for (int i = 0; i < count; i++)
        {
            Coins cc = coinsPool.GetFreeElement();
            Vector3 newPos = pos.position;
            newPos.y += 0.5f;
            cc.transform.position = newPos;

            cc.StartCoins(this);
        }


    }


    public void UpdateCoins(int count) 
    {
        coinsCount += count;
        coins.text = coinsCount.ToString();
    }

    public void OnButtonHealing() 
    {
        if (coinsCount >= 10) 
        {
            player.UpDateHP();
            coinsCount-=10;
            coins.text = coinsCount.ToString();
        }
    }

    public void OnButtonHP()
    {
        Debug.Log("OnButtonHP() ");
    }

    public void OnButtonAttack()
    {
        if (coinsCount >= 10)
        {
            player.UpDateAttack();
            coinsCount -= 10;
            coins.text = coinsCount.ToString();
        }


    }


}
