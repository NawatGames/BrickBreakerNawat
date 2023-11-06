using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PowerUpRepeatableTrigger : MonoBehaviour
{
    [FormerlySerializedAs("PowerUpSuccessEvent")] public UnityEvent<BallHandler> powerUpSuccessEvent;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallHandler>() != null)
        {
            powerUpSuccessEvent.Invoke(other.gameObject.GetComponent<BallHandler>());
        }
    }
}
