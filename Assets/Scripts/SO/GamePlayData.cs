using System;
using UnityEngine;


[CreateAssetMenu(fileName = "NewGamePlayData", menuName = "New GamePlay Data")]
public class GamePlayData : ScriptableObject
{

    [Header("Player Units")]
    [SerializeField]
    public GameObject playerUnitPrefab;

    [Header("Enemy Units")]
    [SerializeField]
    public GameObject enemyUnitPrefab;




}


