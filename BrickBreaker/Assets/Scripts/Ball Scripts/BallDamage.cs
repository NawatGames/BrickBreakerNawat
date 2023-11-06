using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class BallDamage : MonoBehaviour
{
    public int damage = 1;
    private BallCollisionHandler _ballCollisionHandler;
    [FormerlySerializedAs("OnDamageValueChanged")] public UnityEvent onDamageValueChanged;

    private void Awake ()
    {
        _ballCollisionHandler = this.gameObject.GetComponent<BallCollisionHandler>();
    }

    private void TileCollisionDamageEventCaller(Collision2D collision)
    {
        Debug.Log("Tile Hit");
        collision.gameObject.GetComponent<TileHealth>().SubtractHealth(damage, this.gameObject);
    }
    

    private void OnEnable()
    {
        _ballCollisionHandler.tileCollisionEvent.AddListener(TileCollisionDamageEventCaller);
    }

    private void OnDisable()
    {
        _ballCollisionHandler.tileCollisionEvent.RemoveListener(TileCollisionDamageEventCaller);
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
        onDamageValueChanged.Invoke();
    }
}