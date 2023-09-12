using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    public LayerMask newLayer;
    private GameObject ball;

    private void Awake()
    {
        ball = this.gameObject;
    }

    private void OnEnable()
    {
        BallCollisionHandler ballCollisionHandler = ball.GetComponent<BallCollisionHandler>();
        ballCollisionHandler.TileCollisionEvent.AddListener(ChangeBallLayerOnCollision);
        ballCollisionHandler.WallCollisionEvent.AddListener(ChangeBallLayerOnCollision);
    }

    private void OnDisable()
    {
        BallCollisionHandler ballCollisionHandler = ball.GetComponent<BallCollisionHandler>();
        ballCollisionHandler.TileCollisionEvent.RemoveListener(ChangeBallLayerOnCollision);
        ballCollisionHandler.WallCollisionEvent.RemoveListener(ChangeBallLayerOnCollision);
    }

    private void ChangeBallLayerOnCollision()
    {
        Debug.Log("ChangeBallLayerOnCollision");
        ball.layer = LayerMask.NameToLayer("Layer2");
    }
}