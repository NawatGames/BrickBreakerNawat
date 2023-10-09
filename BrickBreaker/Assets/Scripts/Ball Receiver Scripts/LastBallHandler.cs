using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class LastBallHandler : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    
    public bool IsLastBall()
    {
        FakeBallHandler[] fakeBallList = GameObject.FindObjectsOfType<FakeBallHandler>();
        return fakeBallList.Length == gameManager.GetMaxBallCount() - 2 - gameManager.GetDestroyedBallCount();
    }
    public int GetFakeBallCount()
    {
        FakeBallHandler[] fakeBallList = GameObject.FindObjectsOfType<FakeBallHandler>();
        return fakeBallList.Length;
    }
    public int GetBallCount()
    {
        BallHandler[] ballList = GameObject.FindObjectsOfType<BallHandler>();
        return ballList.Length;
    }
}