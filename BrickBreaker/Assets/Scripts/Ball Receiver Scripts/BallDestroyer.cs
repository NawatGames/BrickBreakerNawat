using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallDestroyer : MonoBehaviour
{
    [SerializeField] private ReceiverCollision receiverCollision;
    private void OnReceiverCollision(Collision2D ballCollision)
    {
        if (ballCollision.gameObject.CompareTag("Ball"))
        {
            Destroy(ballCollision.gameObject);
        }
    }

    private void OnEnable()
    {
        receiverCollision.ReceiverCollisionEvent.AddListener(OnReceiverCollision);
    }

    private void OnDisable()
    {
        receiverCollision.ReceiverCollisionEvent.RemoveListener(OnReceiverCollision);
    }
}