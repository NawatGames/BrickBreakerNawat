using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileHealthSpawnSetter : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private TileHealth tileHealth;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        RandomizeHealth();
    }
    
    private void RandomizeHealth()
    {
        int i = UnityEngine.Random.Range(1, 100);
        if (i < 20)
        {
            tileHealth.SetHealth(_gameManager.GetMaxBallCount() * 3 + _gameManager.GetCurrentTurn());
        }
        else
        {
            tileHealth.SetHealth(_gameManager.GetMaxBallCount() + _gameManager.GetCurrentTurn() * 5);
        }
    }
}
