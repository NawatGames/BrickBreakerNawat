using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    public UnityEvent TurnEndEvent;
    public int MaxTurns = 2; // Defina o número máximo de turnos aqui

    private int currentTurn = 0;
    
    //TESTE, TIRAR DEPOIS
    [SerializeField] private FakeBallSpawner fakeBallSpawner;
    
    private void OnEnable()
    {
        fakeBallSpawner.SpawnLastFakeBallEvent.AddListener(EndTurn);
        TurnEndEvent.AddListener(StartTurn);
    }

    private void OnDisable()
    {
        fakeBallSpawner.SpawnLastFakeBallEvent.RemoveListener(EndTurn);
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
}