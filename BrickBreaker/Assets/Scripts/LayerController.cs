using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    public LayerMask newLayer; 
    private GameObject ball; 

    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");

        BallCollisionHandler ballCollisionHandler = ball.GetComponent<BallCollisionHandler>();
        ballCollisionHandler.TileCollisionEvent.AddListener(ChangeBallLayerOnTileCollision);
        ballCollisionHandler.WallCollisionEvent.AddListener(ChangeBallLayerOnWallCollision);
    }
    
    private void ChangeBallLayerOnTileCollision()
    {
        ball.layer = newLayer.value;
    }

    private void ChangeBallLayerOnWallCollision()
    {
        ball.layer = newLayer.value;
    }
}