using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    private ReceiverCollision receiverCollision;

    void Start()
    {
        receiverCollision = FindObjectOfType<ReceiverCollision>();
        if (receiverCollision != null)
        {
            receiverCollision.ReceiverCollisionEvent.AddListener(DestroyBall);
        }
    }

    void DestroyBall()
    {
        if (gameObject.CompareTag("Bolinha"))//Tag do objeto a ser destruido
        {
            Destroy(gameObject);
        }
    }
}