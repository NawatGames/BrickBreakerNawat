using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class LastBallHandler : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public GameObject[] ballList;
    
    
    public bool IsLastBall()
    {
        GameObject[] fakeBallList = GameObject.FindGameObjectsWithTag("FakeBall");
        return fakeBallList.Length == gameManager.GetMaxBallCount() - 2;
    }
    public int GetBallCount()
    {
        return ballList.Length;
    }
}