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
    [FormerlySerializedAs("FirstFakeBall")] public GameObject firstFakeBall;

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
        gameManager.turnEndEvent.AddListener(ResetIsFirstFakeBall);
    }
    
    private void OnDisable()
    {
        gameManager.turnEndEvent.RemoveListener(ResetIsFirstFakeBall);
    }

    public bool IsFirstFakeBall()
    {
        return isFirstFakeBall;
    }
}