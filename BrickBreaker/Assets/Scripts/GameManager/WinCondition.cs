using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinCondition : MonoBehaviour
{   
    [SerializeField] private TileRowSpawner tileRowSpawner;

    [SerializeField] private GameManager gameManager;
    public UnityEvent WinEvent;

    private bool _isLevelOver;

    private void Awake()
    {
        _isLevelOver = false;
    }

    // Start is called before the first frame update
    private void OnTurnEnd()
    {
        if (_isLevelOver)
        {
            TileHealth[] tileRows = GameObject.FindObjectsOfType<TileHealth>(); //Trocar futuramente para o TileHolder
            if (tileRows.Length == 0)
            {
                WinEvent.Invoke();
            }
        }
    }

    private void OnEndOfLevel()
    {
        _isLevelOver = true;
    }

    private void OnEnable()
    {
        gameManager.turnEndEvent.AddListener(OnTurnEnd);
        tileRowSpawner.EndOfLevelEvent.AddListener(OnEndOfLevel);
    }
}
