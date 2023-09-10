using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LayerController : MonoBehaviour
{
    public LayerMask newLayer;
    private GameObject ball; 

    public UnityEvent TileCollisionLayerChangeEvent; 
    public UnityEvent WallCollisionLayerChangeEvent; 

    private void Awake()
    {
        
        ball = GameObject.FindGameObjectWithTag("Ball");

        
        BallCollisionHandler ballCollisionHandler = ball.GetComponent<BallCollisionHandler>();
        ballCollisionHandler.TileCollisionEvent.AddListener(ChangeBallLayerOnTileCollision);
        ballCollisionHandler.WallCollisionEvent.AddListener(ChangeBallLayerOnWallCollision);
    }
    
    private void ChangeBallLayerOnTileCollision()
    {
        
        if (ball != null)
        {
            // Altera a LayerMask da bolinha
            ball.layer = LayerMask.NameToLayer(newLayer.ToString());

            // Dispara o evento TileCollisionLayerChangeEvent
            TileCollisionLayerChangeEvent.Invoke();
        }
    }

    // Função para alterar a LayerMask da bolinha em colisão com Parede
    private void ChangeBallLayerOnWallCollision()
    {
        // Verifica se a bolinha existe
        if (ball != null)
        {
            // Altera a LayerMask da bolinha
            ball.layer = LayerMask.NameToLayer(newLayer.ToString());

            // Dispara o evento WallCollisionLayerChangeEvent
            WallCollisionLayerChangeEvent.Invoke();
        }
    }
}
