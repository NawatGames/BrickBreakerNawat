
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

    private void ChangeBallLayerOnCollision(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Wall") || collision2D.gameObject.CompareTag("Tile"))
        {
            Debug.Log("ChangeBallLayerOnCollision");
            root.layer = LayerMask.NameToLayer("BallLayer2");
        }
    }
}