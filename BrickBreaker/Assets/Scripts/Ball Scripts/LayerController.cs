
using UnityEngine;

public class LayerController : MonoBehaviour
{
    public LayerMask newLayer;
    [SerializeField]
    private GameObject root;

    private void OnEnable()
    {
        BallCollisionHandler ballCollisionHandler = root.GetComponent<BallCollisionHandler>();
        ballCollisionHandler.tileCollisionEvent.AddListener(ChangeBallLayerOnCollision);
        ballCollisionHandler.wallCollisionEvent.AddListener(ChangeBallLayerOnCollision);
    }

    private void OnDisable()
    {
        BallCollisionHandler ballCollisionHandler = root.GetComponent<BallCollisionHandler>();
        ballCollisionHandler.tileCollisionEvent.RemoveListener(ChangeBallLayerOnCollision);
        ballCollisionHandler.wallCollisionEvent.RemoveListener(ChangeBallLayerOnCollision);
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