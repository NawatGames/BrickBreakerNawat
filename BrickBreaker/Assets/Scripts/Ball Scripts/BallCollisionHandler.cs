using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class BallCollisionHandler : MonoBehaviour
{
    [FormerlySerializedAs("TileCollisionEvent")] public UnityEvent<Collision2D> tileCollisionEvent; //Evento de colisão com os Tiles

    [FormerlySerializedAs("WallCollisionEvent")] public UnityEvent<Collision2D> wallCollisionEvent; //Evento de colisão com as Paredes

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            tileCollisionEvent.Invoke(collision);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            wallCollisionEvent.Invoke(collision);
        }
    }
}