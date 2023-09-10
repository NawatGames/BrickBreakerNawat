using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallDamage : MonoBehaviour
{
    public int damage = 10;
    public UnityEvent<int> TileCollisionDamegeEvent;
    private BallCollisionHandler ballCollisionHandler;
    private void Awake()
    {
        ballCollisionHandler = GetComponentInParent<BallCollisionHandler>();

    }
    private void OnEnable()
    {
        ballCollisionHandler.TileCollisionEvent.AddListener(TileCollisionDamegeEventCaller);
    }
    private void OnDisable()
    {
        ballCollisionHandler.TileCollisionEvent.RemoveListener(TileCollisionDamegeEventCaller);
    }
    private void TileCollisionDamegeEventCaller()
    {
        TileCollisionDamegeEvent.Invoke(damage);
    }
}