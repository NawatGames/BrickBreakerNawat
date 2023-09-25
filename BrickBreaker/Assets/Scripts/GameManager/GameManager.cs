using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent TurnEndEvent;
    public int MaxTurns = 2; // Defina o número máximo de turnos aqui
    private int MaxBallCount = 30;

    private int currentTurn = 0;
    
    private void OnEnable()
    {
        TurnEndEvent.AddListener(StartTurn);
    }

    private void OnDisable()
    {
        TurnEndEvent.RemoveListener(StartTurn);
    }
    //

    void Start()
    {
        StartTurn();
    }

    public void StartTurn()
    {
        currentTurn++;

        if (currentTurn <= MaxTurns)
        {
            Debug.Log("Turno " + currentTurn);
        }
        else
        {
            Debug.Log("Fim do jogo!");
        }
    }

    public void EndTurn(Vector2 position)
    {
        TurnEndEvent.Invoke();
    }

    public int GetCurrentTurn()
    {
        return currentTurn;
    }
    
    public int GetMaxBallCount()
    {
        return MaxBallCount;
    }
    public void SetMaxBallCount(int newMaxBallCount)
    {
        MaxBallCount = newMaxBallCount;
    }
}