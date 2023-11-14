using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class BallDamage : MonoBehaviour
{
    public int damage = 1;
    private BallCollisionHandler ballCollisionHandler;
    public UnityEvent OnDamageValueChanged;

    private void Awake ()
    {
        ballCollisionHandler = this.gameObject.GetComponent<BallCollisionHandler>();
    }

    private void TileCollisionDamageEventCaller(Collision2D collision)
    {
        Debug.Log("Tile Hit");
        collision.gameObject.GetComponent<TileHealth>().SubtractHealth(damage, this.gameObject);
    }
    

    private void OnEnable()
    {
        ballCollisionHandler.TileCollisionEvent.AddListener(TileCollisionDamageEventCaller);
    }

    private void OnDisable()
    {
        ballCollisionHandler.TileCollisionEvent.RemoveListener(TileCollisionDamageEventCaller);
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
        OnDamageValueChanged.Invoke();
    }
    public int GetDamage()
    {
        return damage;
    }
}