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
            
            ball.layer = LayerMask.NameToLayer(newLayer.ToString());

            
            TileCollisionLayerChangeEvent.Invoke();
        }
    }

    
    private void ChangeBallLayerOnWallCollision()
    {
        
        if (ball != null)
        {
            
            ball.layer = LayerMask.NameToLayer(newLayer.ToString());

            
            WallCollisionLayerChangeEvent.Invoke();
        }
    }
}
