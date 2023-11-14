using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallDestroyer : MonoBehaviour
{
    [SerializeField] private ReceiverCollision receiverCollision;
    private void OnReceiverCollision(Transform transform)
    {
        if (transform.gameObject.CompareTag("Ball"))
        {
            Destroy(transform.gameObject);
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