using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCollisionHandler : MonoBehaviour
{
    public GameObject tile;

    public UnityEvent TileCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == tile)
        {
            TileCollision.Invoke();
        }
    }
}
