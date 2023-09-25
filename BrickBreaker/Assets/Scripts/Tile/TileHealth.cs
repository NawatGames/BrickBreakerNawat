using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TileHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    public UnityEvent NoHealthEvent;
    public UnityEvent<int> TileHitEvent;
    public UnityEvent<int> TileHealthChangedEvent;
    
    private void OnTileHit(int damage)
    {
        health -= damage;
        TileHealthChangedEvent.Invoke(health);
        if (health <= 0)
        {
            NoHealthEvent.Invoke();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void OnEnable()
    {
        TileHitEvent.AddListener(OnTileHit);
    }

    private void OnDisable()
    {
        TileHitEvent.RemoveListener(OnTileHit);
    }
}
