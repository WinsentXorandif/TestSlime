using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    float speed = 2f;

    void Start()
    {
        transform.parent = null;
        transform.eulerAngles = new Vector3(90f, 0f, 0f);
        
    }

    public async void StartCoins(UIControl ui) 
    {
        await transform.DOMove(ui.coinsImage.position, speed).SetEase(Ease.InOutSine).AsyncWaitForCompletion();
        this.gameObject.SetActive(false);

        ui.UpdateCoins(1);



    }



}
