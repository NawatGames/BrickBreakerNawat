using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ReceiverCollision : MonoBehaviour
{

    [FormerlySerializedAs("ReceiverCollisionEvent")] public UnityEvent<Transform> receiverCollisionEvent;
    [SerializeField] private GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
            // Dispara o evento de colisão com o Receiver.
            if(collision.gameObject.CompareTag("Ball"))
                receiverCollisionEvent.Invoke(collision.transform);
            if(collision.gameObject.CompareTag("Tile"))
                gameManager.gameOverEvent.Invoke();
    }
}