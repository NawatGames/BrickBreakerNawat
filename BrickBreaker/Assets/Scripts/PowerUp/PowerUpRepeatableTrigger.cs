using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUpRepeatableTrigger : MonoBehaviour
{
    public UnityEvent<BallHandler> PowerUpSuccessEvent;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallHandler>() != null)
        {
            PowerUpSuccessEvent.Invoke(other.gameObject.GetComponent<BallHandler>());
        }
    }
}
