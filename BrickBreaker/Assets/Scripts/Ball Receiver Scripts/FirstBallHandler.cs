using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


public class FirstBallHandler : MonoBehaviour
{
    [FormerlySerializedAs("turnManager")] [SerializeField] private GameManager gameManager;
    public bool isFirstFakeBall;
    public GameObject FirstFakeBall;

    private void Start()
    {
        isFirstFakeBall = true;
    }

    public void FlipIsFirstFakeBall()
    {
        isFirstFakeBall = false;
    }

    public void ResetIsFirstFakeBall()
    {
        isFirstFakeBall = true;
    }

    private void OnEnable()
    {
        gameManager.TurnEndEvent.AddListener(ResetIsFirstFakeBall);
    }
    
    private void OnDisable()
    {
        gameManager.TurnEndEvent.RemoveListener(ResetIsFirstFakeBall);
    }

    public bool IsFirstFakeBall()
    {
        return isFirstFakeBall;
    }
}