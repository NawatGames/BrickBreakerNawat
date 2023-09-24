using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LastBallHandler : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    public GameObject[] ballList;

    private void Update()
    {
        ballList = GameObject.FindGameObjectsWithTag("Ball");
    }
    
    public bool IsLastBall()
    {
        return ballList.Length == 1;
    }
}