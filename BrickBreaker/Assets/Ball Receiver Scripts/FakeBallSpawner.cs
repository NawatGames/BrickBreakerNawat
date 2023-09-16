using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBallSpawner : MonoBehaviour
{
    public FirstBallHandler firstBallHandler;
    public GameObject fakeBallPrefab; 
    public GameObject FirstFakeBallPrefab;     private ReceiverCollision receiverCollision; 

    void Start()
    {
        receiverCollision = FindObjectOfType<ReceiverCollision>();

        if (receiverCollision != null)
        {
            receiverCollision.ReceiverCollisionEvent.AddListener(Check);
        }
    }

    void Check()
    {
        // Verificar se isFirstFakeBall é verdadeiro
        if (firstBallHandler.isFirstFakeBall)
            SpawnFirstFakeBall();
        else
            NormalFakeBall();
    }

    void SpawnFirstFakeBall()
    {
        if (FirstFakeBallPrefab != null)
        {
            Instantiate(FirstFakeBallPrefab, receiverCollision.transform.position, Quaternion.identity);
        }
    }

    public void NormalFakeBall()
    {
        GameObject fakeBall = Instantiate(fakeBallPrefab, transform.position, Quaternion.identity);
    }
}