using UnityEngine;
using UnityEngine.Events;

public class ReceiverCollision : MonoBehaviour
{

    public UnityEvent<Transform> ReceiverCollisionEvent;
    [SerializeField] private GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
            // Dispara o evento de colisão com o Receiver.
            if(collision.gameObject.CompareTag("Ball"))
                ReceiverCollisionEvent.Invoke(collision.transform);
            if(collision.gameObject.CompareTag("Tile"))
                gameManager.gameOverEvent.Invoke();
    }
}