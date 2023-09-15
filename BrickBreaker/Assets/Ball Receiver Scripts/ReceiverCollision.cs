using UnityEngine;
using UnityEngine.Events;

public class ReceiverCollision : MonoBehaviour
{
    // Evento Unity para notificar colisões com o Receiver.
    public UnityEvent ReceiverCollisionEvent;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão envolve o jogador (Bolinha).
        if (collision.gameObject.CompareTag("Bolinha"))
        {
            // Dispara o evento de colisão com o Receiver.
            ReceiverCollisionEvent.Invoke();
        }
    }
}