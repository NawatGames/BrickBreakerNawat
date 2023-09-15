using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    public LayerMask newLayer;
    [SerializeField]
    private GameObject root;

    private void OnEnable()
    {
        BallCollisionHandler ballCollisionHandler = root.GetComponent<BallCollisionHandler>();
        ballCollisionHandler.TileCollisionEvent.AddListener(ChangeBallLayerOnCollision);
        ballCollisionHandler.WallCollisionEvent.AddListener(ChangeBallLayerOnCollision);
    }

    private void OnDisable()
    {
        BallCollisionHandler ballCollisionHandler = root.GetComponent<BallCollisionHandler>();
        ballCollisionHandler.TileCollisionEvent.RemoveListener(ChangeBallLayerOnCollision);
        ballCollisionHandler.WallCollisionEvent.RemoveListener(ChangeBallLayerOnCollision);
    }

    private void ChangeBallLayerOnCollision()
    {
        Debug.Log("ChangeBallLayerOnCollision");
        root.layer = LayerMask.NameToLayer("Layer2");
    }
}