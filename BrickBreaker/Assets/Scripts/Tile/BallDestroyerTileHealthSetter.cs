using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyerTileHealthSetter : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] protected TileHealth tileHealth;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        RandomizeHealth();
    }
    
    private void RandomizeHealth()
    {
        tileHealth.SetHealth(Mathf.FloorToInt(_gameManager.GetMaxBallCount()/2));
    }
}
