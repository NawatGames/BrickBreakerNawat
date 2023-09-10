using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCollisionHandler : MonoBehaviour
{
    public UnityEvent TileCollisionEvent; //Evento de colisão com os Tiles

    public UnityEvent WallCollisionEvent; //Evento de colisão com as Paredes

    private void OnTileCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            TileCollisionEvent.Invoke();
        }
    }

    private void OnWallCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallCollisionEvent.Invoke();
        }
    }
}