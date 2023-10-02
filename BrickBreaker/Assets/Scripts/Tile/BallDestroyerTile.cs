using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyerTile : MonoBehaviour
{
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BallHandler>() != null)
        {
            Destroy(other.gameObject);
            _gameManager.BallDestroyedEvent.Invoke();
        }
    }
}
