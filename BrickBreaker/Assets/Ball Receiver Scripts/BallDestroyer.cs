using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallDestroyer : MonoBehaviour
{
    [SerializeField] private ReceiverCollision receiverCollision;
    private void OnBallCollisionEnter(Collision2D ballCollision)
    {
        if (ballCollision.gameObject.CompareTag("Ball"))
        {
            Destroy(ballCollision.gameObject);
        }
    }

    private void OnEnable()
    {
        receiverCollision.ReceiverCollisionEvent.AddListener(OnBallCollisionEnter);
    }

    private void OnDisable()
    {
        receiverCollision.ReceiverCollisionEvent.RemoveListener(OnBallCollisionEnter);
    }
}