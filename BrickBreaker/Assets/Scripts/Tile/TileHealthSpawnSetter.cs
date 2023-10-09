using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileHealthSpawnSetter : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private TileHealth tileHealth;

    [SerializeField] private float steepness = 0.1f; // Ajuste a inclinação da função logística
    [SerializeField] private float midpoint = 40f; // Ajuste a posição do ponto médio para a transição
    [SerializeField] private float multiplier = 50f;

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        RandomizeHealth();
    }
    
    private void RandomizeHealth()
    {
        int i = UnityEngine.Random.Range(1, 100);
        if (i < 20)
        {
            tileHealth.SetHealth(_gameManager.GetMaxBallCount() * 2 + LogisticFunction(_gameManager.GetCurrentTurn()));
        }
        else
        {
            tileHealth.SetHealth(_gameManager.GetMaxBallCount() + LogisticFunction(_gameManager.GetCurrentTurn()));
        }
    }

    private int LogisticFunction(int x)
    {
        // Função logística com ajuste para crescimento gradual a partir de x = 100
        return (int)(multiplier / (1f + Mathf.Exp(-steepness * (x - midpoint))));
    }
}
