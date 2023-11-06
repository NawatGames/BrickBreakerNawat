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
    private ReceiverCollision _receiverCollision;
    [FormerlySerializedAs("SpawnFirstFakeBallEvent")] public UnityEvent<Vector2> spawnFirstFakeBallEvent;
    [FormerlySerializedAs("SpawnLastFakeBallEvent")] public UnityEvent<Vector2> spawnLastFakeBallEvent;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _receiverCollision = FindObjectOfType<ReceiverCollision>();
        if (_receiverCollision != null)
        {
            _receiverCollision.receiverCollisionEvent.AddListener(Check);
        }
        if (_gameManager != null)
        {
            _gameManager.ballDestroyedEvent.AddListener(OnBallDestroyed);
        }
    }

    void Check(Transform transform)
    {
        // Verificar se isFirstFakeBall é verdadeiro
        if (lastBallHandler.IsLastBall())
        {
            spawnLastFakeBallEvent.Invoke(new Vector2(transform.position.x, -4));
        }
        else
        {
            if (firstBallHandler.IsFirstFakeBall())
            {
                spawnFirstFakeBallEvent.Invoke(new Vector2(transform.position.x, -4));
                firstBallHandler.FlipIsFirstFakeBall();
            }
            else
                NormalFakeBall(new Vector2(transform.position.x, -4));
        }
    }

    private void OnEnable()
    {

        spawnFirstFakeBallEvent.AddListener(SpawnFirstFakeBall);
        spawnLastFakeBallEvent.AddListener(SpawnLastFakeBall);
    }

    private void OnBallDestroyed()
    {
        StartCoroutine(WaitUntilFirstFakeBall());
    }

    private IEnumerator WaitUntilFirstFakeBall()
    {
        while (firstBallHandler.IsFirstFakeBall())
        {
            yield return null;
        }
        GameObject firstFakeBall = GameObject.FindGameObjectWithTag("FirstFakeBall");
        Transform firstFakeBallTransform = firstFakeBall.transform;
        Check(firstFakeBallTransform);
    }

    private void OnDisable()
    {
        spawnFirstFakeBallEvent.RemoveListener(SpawnFirstFakeBall);
        spawnLastFakeBallEvent.RemoveListener(SpawnLastFakeBall);
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