using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCollisionHandler : MonoBehaviour
{
    public UnityEvent<TileCollisionHandler> TileCollisionEvent; //Evento de colisão com os Tiles

    public UnityEvent<Collision2D> WallCollisionEvent; //Evento de colisão com as Paredes

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TileCollisionHandler tileCollisionHandler = collision.gameObject.GetComponent<TileCollisionHandler>();
        
        if (tileCollisionHandler != null)
        {
            TileCollisionEvent.Invoke(tileCollisionHandler);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallCollisionEvent.Invoke(collision);
        }
    }
}