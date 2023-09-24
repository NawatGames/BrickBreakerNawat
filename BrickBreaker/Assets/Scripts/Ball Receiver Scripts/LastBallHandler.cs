using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class LastBallHandler : MonoBehaviour
{
    [FormerlySerializedAs("turnManager")] [SerializeField] private GameManager gameManager;
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