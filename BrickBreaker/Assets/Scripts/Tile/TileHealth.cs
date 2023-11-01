using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TileHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    public UnityEvent noHealthEvent;
    public UnityEvent<GameObject> tileHitEvent;
    public UnityEvent<int> tileHealthChangedEvent;

    public void SubtractHealth(int damage, GameObject ball)
    {
        
        health -= damage;
        tileHitEvent.Invoke(ball);
        tileHealthChangedEvent.Invoke(health);
        Debug.Log("Hit");
        if (health <= 0)
        {
            noHealthEvent.Invoke();
        }
    }

    public void SetHealth(int health)
    {
        this.health = health;
        tileHealthChangedEvent.Invoke(health);
    }

    public int GetHealth()
    {
        return health;
    }
    
}
