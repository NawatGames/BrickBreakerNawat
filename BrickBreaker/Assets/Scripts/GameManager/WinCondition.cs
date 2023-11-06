using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class WinCondition : MonoBehaviour
{   
    [SerializeField] private TileRowSpawner tileRowSpawner;

    [SerializeField] private GameManager gameManager;
    [FormerlySerializedAs("WinEvent")] public UnityEvent winEvent;

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
            GameObject[] tileRows = GameObject.FindGameObjectsWithTag("Tile");
            if (tileRows.Length == 0)
            {
                winEvent.Invoke();
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
        tileRowSpawner.endOfLevelEvent.AddListener(OnEndOfLevel);
    }
}
