using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent turnEndEvent;
    public UnityEvent gameOverEvent;
    public int maxTurns = 2; // Defina o número máximo de turnos aqui
    [SerializeField] int maxBallCount = 3000;
    private int _destroyedBallCount = 0;
    private int _adderCount = 0;
    public UnityEvent ballDestroyedEvent;

    private int _currentTurn;

    private void Awake()
    {
        _currentTurn = 1;
    }

    private void OnEnable()
    {
        turnEndEvent.AddListener(StartTurn);
        turnEndEvent.AddListener(OnTurnEndSetMaxBallCount);
        turnEndEvent.AddListener(OnTurnEndResetDestroyedBallCount);
        ballDestroyedEvent.AddListener(OnBallDestroyed);
    }

    private void OnDisable()
    {
        turnEndEvent.RemoveListener(StartTurn);
        turnEndEvent.RemoveListener(OnTurnEndSetMaxBallCount);
        turnEndEvent.RemoveListener(OnTurnEndResetDestroyedBallCount);
        ballDestroyedEvent.RemoveListener(OnBallDestroyed);
    }
    //


    public void StartTurn()
    {
        _currentTurn++;

        if (_currentTurn <= maxTurns)
        {
            Debug.Log("Turno " + _currentTurn);
        }
        else
        {
            Debug.Log("Fim do jogo!");
        }
    }

    public void EndTurn(Vector2 position)
    {
        turnEndEvent.Invoke();
    }

    public int GetCurrentTurn()
    {
        return _currentTurn;
    }

    public int GetMaxBallCount()
    {
        return maxBallCount;
    }

    public int GetDestroyedBallCount()
    {
        return _destroyedBallCount;
    }

    public void OnAdderTrigger()
    {
        _adderCount++;
    }
    private void OnTurnEndSetMaxBallCount()
    {
        maxBallCount = GetMaxBallCount() + _adderCount;
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