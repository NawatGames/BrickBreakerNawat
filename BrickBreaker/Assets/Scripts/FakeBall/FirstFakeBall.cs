using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFakeBall : MonoBehaviour
{
    private GameManager _gameManager;
    private LastBallHandler _lastBallHandler;

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _lastBallHandler = GameObject.FindObjectOfType<LastBallHandler>();
    }

    private void OnEnable()
    {
        _gameManager.TurnEndEvent.AddListener(OnTurnEnd);
    }

    private void OnDisable()
    {
        _gameManager.TurnEndEvent.RemoveListener(OnTurnEnd);
    }

    private void OnTurnEnd()
    {
        Destroy(this.gameObject);
    }
}
