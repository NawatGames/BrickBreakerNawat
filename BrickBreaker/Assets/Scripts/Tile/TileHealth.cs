using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TileHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    public UnityEvent NoHealthEvent;
    public UnityEvent<GameObject> TileHitEvent;
    public UnityEvent<int> TileHealthChangedEvent;

    public void SubtractHealth(int damage, GameObject ball)
    {
        
        health -= damage;
        TileHitEvent.Invoke(ball);
        TileHealthChangedEvent.Invoke(health);
        Debug.Log("Hit");
        if (health <= 0)
        {
            NoHealthEvent.Invoke();
        }
    }

    public void SetHealth(int health)
    {
        this.health = health;
        TileHealthChangedEvent.Invoke(health);
    }

    public int GetHealth()
    {
        return health;
    }
    
}
