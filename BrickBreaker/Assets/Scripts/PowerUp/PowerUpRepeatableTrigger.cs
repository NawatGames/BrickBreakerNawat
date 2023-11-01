using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUpRepeatableTrigger : MonoBehaviour
{
    public UnityEvent<BallHandler> powerUpSuccessEvent;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallHandler>() != null)
        {
            powerUpSuccessEvent.Invoke(other.gameObject.GetComponent<BallHandler>());
        }
    }
}
