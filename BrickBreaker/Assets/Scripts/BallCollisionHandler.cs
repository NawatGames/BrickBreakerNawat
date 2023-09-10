using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCollisionHandler : MonoBehaviour
{
    public GameObject wall;

    public GameObject tile;

    public UnityEvent WallCollisionEvent;

    public UnityEvent TileCollisionEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == tile)
        {
            TileCollisionEvent.Invoke();
        }
    }
}