using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyerTile : MonoBehaviour
{
    private GameManager _gameManager;
    private LastBallHandler _lastBallHandler;
    private void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _lastBallHandler = GameObject.FindObjectOfType<LastBallHandler>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BallHandler>() != null)
        {
            if(_lastBallHandler.GetBallCount() == 1)
            {
                if(_gameManager.GetDestroyedBallCount() == _gameManager.GetMaxBallCount() - 1)
                {
                    _gameManager.gameOverEvent.Invoke();
                }
                _gameManager.turnEndEvent.Invoke();
            }
            Destroy(other.gameObject);
            _gameManager.ballDestroyedEvent.Invoke();
        }
    }
}
