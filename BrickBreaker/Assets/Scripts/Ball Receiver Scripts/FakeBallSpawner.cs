using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class FakeBallSpawner : MonoBehaviour
{
    public FirstBallHandler firstBallHandler;
    [SerializeField] private LastBallHandler lastBallHandler;
    public GameObject fakeBallPrefab; 
    public GameObject firstFakeBallPrefab;
    public GameObject lastFakeBallPrefab;
    private ReceiverCollision receiverCollision;
    public UnityEvent<Vector2> SpawnFirstFakeBallEvent;
    public UnityEvent<Vector2> SpawnLastFakeBallEvent;

    void Start()
    {
        receiverCollision = FindObjectOfType<ReceiverCollision>();

        if (receiverCollision != null)
        {
            receiverCollision.ReceiverCollisionEvent.AddListener(Check);
        }
    }

    void Check(Collision2D ballCollision)
    {
        // Verificar se isFirstFakeBall é verdadeiro
        if (lastBallHandler.IsLastBall())
        {
            SpawnLastFakeBallEvent.Invoke(new Vector2(ballCollision.transform.position.x, -4));
        }
        else
        {
            if (firstBallHandler.IsFirstFakeBall())
            {
                SpawnFirstFakeBallEvent.Invoke(new Vector2(ballCollision.transform.position.x, -4));
                firstBallHandler.FlipIsFirstFakeBall();
            }
            else
                NormalFakeBall(new Vector2(ballCollision.transform.position.x, -4));
        }
    }

    private void OnEnable()
    {
        SpawnFirstFakeBallEvent.AddListener(SpawnFirstFakeBall);
        SpawnLastFakeBallEvent.AddListener(SpawnLastFakeBall);
    }

    private void OnDisable()
    {
        SpawnFirstFakeBallEvent.RemoveListener(SpawnFirstFakeBall);
        SpawnLastFakeBallEvent.RemoveListener(SpawnLastFakeBall);
    }
    
    void SpawnFirstFakeBall(Vector2 position)
    {
        if (firstFakeBallPrefab != null)
        {
            Instantiate(firstFakeBallPrefab, position, Quaternion.identity);
        }
    }
    
    public void NormalFakeBall(Vector2 position)
    {
        if (fakeBallPrefab != null)
        {
            Instantiate(fakeBallPrefab, position, Quaternion.identity);
        }
    }
    
    public void SpawnLastFakeBall(Vector2 position)
    {
        if (lastFakeBallPrefab != null)
        {
            Instantiate(lastFakeBallPrefab, position, Quaternion.identity);
        }
    }
}