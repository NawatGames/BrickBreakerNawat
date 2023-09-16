using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class FirstBallHandler : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    public bool isFirstFakeBall;
    public GameObject FirstFakeBall;

    private void Start()
    {
        isFirstFakeBall = true;
    }

    public void FlipIsFirstFakeBall()
    {
        isFirstFakeBall = !isFirstFakeBall;
    }

    private void OnEnable()
    {
        turnManager.TurnEndEvent.AddListener(FlipIsFirstFakeBall);
    }
    
    private void OnDisable()
    {
        turnManager.TurnEndEvent.RemoveListener(FlipIsFirstFakeBall);
    }

    public bool IsFirstFakeBall()
    {
        return isFirstFakeBall;
    }
}