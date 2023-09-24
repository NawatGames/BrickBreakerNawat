using UnityEngine;
using UnityEngine.Events;

public class ReceiverCollision : MonoBehaviour
{

    public UnityEvent<Collision2D> ReceiverCollisionEvent;
    private void OnCollisionEnter2D(Collision2D collision)
    {
            // Dispara o evento de colisão com o Receiver.
            if(collision.gameObject.CompareTag("Ball"))
                ReceiverCollisionEvent.Invoke(collision);
    }
}