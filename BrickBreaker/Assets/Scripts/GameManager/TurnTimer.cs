using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTimer : MonoBehaviour
{
    private GameManager gameManager;
    private float maxTurnTime = 20f;
    private float currentTurnTime;
    private bool isTurnActive = false;
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    
    private void OnEnable()
    {
        gameManager.TurnStartEvent.AddListener(ResetTimer);
    }

    private void ResetTimer(int turn)
    {
        currentTurnTime = 0f;
        isTurnActive = true;
    }
    
    private void Update()
    {
        if (isTurnActive)
        {
            currentTurnTime += Time.deltaTime;
            if (currentTurnTime >= maxTurnTime)
            {
                GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
                foreach (GameObject ball in balls)
                {
                    ball.GetComponent<Rigidbody2D>().velocity *= 5f;
                }
                isTurnActive = false;
            }
        }
    }
}
