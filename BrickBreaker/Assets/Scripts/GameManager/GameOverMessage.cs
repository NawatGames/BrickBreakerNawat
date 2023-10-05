using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMessage : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnGameOver()
    {
        SceneManager.LoadScene(1);
    }

    private void OnEnable()
    {
        gameManager.gameOverEvent.AddListener(OnGameOver);
    }

    private void OnDisable()
    {
        gameManager.gameOverEvent.RemoveListener(OnGameOver);
    }
}
