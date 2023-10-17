using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyerTile : MonoBehaviour
{
    private GameManager _gameManager;
    private LastBallHandler _lastBallHandler;
    private TileHealth _tileHealth;
    private void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _lastBallHandler = GameObject.FindObjectOfType<LastBallHandler>();
        _tileHealth = this.gameObject.GetComponent<TileHealth>();
    }

    private void OnTileHit(GameObject ball)
    {
        if(_lastBallHandler.GetBallCount() == 1)
        {
            if(_gameManager.GetDestroyedBallCount() == _gameManager.GetMaxBallCount() - 1)
            {
                _gameManager.GameOverEvent.Invoke();
            }
            _gameManager.TurnEndEvent.Invoke();
        }
        Destroy(ball);
        _gameManager.BallDestroyedEvent.Invoke();
    }
    
    private void OnEnable()
    {
        _tileHealth.TileHitEvent.AddListener(OnTileHit);
    }
    
    private void OnDisable()
    {
        _tileHealth.TileHitEvent.RemoveListener(OnTileHit);
    }
}
