using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCollisionHandler : MonoBehaviour
{

    public UnityEvent<Collision2D> TileCollisionEvent; //Evento de colisão com os Tiles

    public UnityEvent<Collision2D> WallCollisionEvent; //Evento de colisão com as Paredes

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            TileCollisionEvent.Invoke(collision);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallCollisionEvent.Invoke(collision);
        }
    }
}