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
        GameObject[] fakeBallList = GameObject.FindGameObjectsWithTag("FakeBall");
        return fakeBallList.Length == gameManager.GetMaxBallCount() - 2 - gameManager.GetDestroyedBallCount();
    }
    public int GetFakeBallCount()
    {
        GameObject[] fakeBallList = GameObject.FindGameObjectsWithTag("FakeBall");
        return fakeBallList.Length;
    }
    public int GetBallCount()
    {
        GameObject[] ballList = GameObject.FindGameObjectsWithTag("Ball");
        return ballList.Length;
    }
}