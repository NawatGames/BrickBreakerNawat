using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class BallDamage : MonoBehaviour
{
    public int damage = 10;
    public IntEvent TileCollisionDamageEvent; 
    private BallCollisionHandler ballCollisionHandler;
    public UnityEvent OnDamageValueChanged;

    private void Awake ()
    {
        ballCollisionHandler = GetComponentInParent<BallCollisionHandler>();
    }

    private void OnEnable ()
    {
        ballCollisionHandler.TileCollisionEvent.AddListener(TileCollisionDamageEventCaller);
    }

    private void OnDisable ()
    {
        ballCollisionHandler.TileCollisionEvent.RemoveListener(TileCollisionDamageEventCaller);
    }

    private void TileCollisionDamageEventCaller()
    {
        TileCollisionDamageEvent.Invoke(damage);
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
        OnDamageValueChanged.Invoke();
    }
}