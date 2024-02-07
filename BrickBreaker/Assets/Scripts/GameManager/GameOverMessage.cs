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
        SceneManager.LoadScene(4);
    }

    private void OnEnable()
    {
        gameManager.GameOverEvent.AddListener(OnGameOver);
    }

    private void OnDisable()
    {
        gameManager.GameOverEvent.RemoveListener(OnGameOver);
    }
}
