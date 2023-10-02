using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent TurnEndEvent;
    public UnityEvent GameOverEvent;
    public int MaxTurns = 2; // Defina o número máximo de turnos aqui
    [SerializeField] int MaxBallCount = 3000;
    private int _destroyedBallCount = 0;
    private int _adderCount = 0;
    public UnityEvent BallDestroyedEvent;

    private int currentTurn;

    private void Awake()
    {
        currentTurn = 1;
    }

    private void OnEnable()
    {
        TurnEndEvent.AddListener(StartTurn);
        TurnEndEvent.AddListener(OnTurnEndSetMaxBallCount);
        TurnEndEvent.AddListener(OnTurnEndResetDestroyedBallCount);
        BallDestroyedEvent.AddListener(OnBallDestroyed);
    }

    private void OnDisable()
    {
        TurnEndEvent.RemoveListener(StartTurn);
        TurnEndEvent.RemoveListener(OnTurnEndSetMaxBallCount);
        TurnEndEvent.RemoveListener(OnTurnEndResetDestroyedBallCount);
        BallDestroyedEvent.RemoveListener(OnBallDestroyed);
    }
    //


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

    public void OnAdderTrigger()
    {
        _adderCount++;
    }
    private void OnTurnEndSetMaxBallCount()
    {
        MaxBallCount = GetMaxBallCount() + _adderCount;
        _adderCount = 0;
    }

    private void OnTurnEndResetDestroyedBallCount()
    {
        _destroyedBallCount = 0;
    }

    private void OnBallDestroyed()
    {
        _destroyedBallCount++;
        Debug.Log("BallDestroyed");
        if (_destroyedBallCount >= MaxBallCount)
        {
            GameOverEvent.Invoke();
        }
    }
}