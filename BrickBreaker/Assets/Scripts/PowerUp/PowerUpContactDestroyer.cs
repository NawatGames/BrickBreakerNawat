using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpContactDestroyer : MonoBehaviour
{
    [SerializeField] private PowerUpRepeatableTrigger powerUpRepeatableTrigger;
    [SerializeField] private PowerUpUniqueTrigger powerUpUniqueTrigger;


    private void OnPowerUpSuccess(BallHandler ballHandler)
    {
        Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        if (powerUpRepeatableTrigger != null)
        {
            powerUpRepeatableTrigger.powerUpSuccessEvent.AddListener(OnPowerUpSuccess);
        }

        if (powerUpUniqueTrigger != null)
        {
            powerUpUniqueTrigger.PowerUpSuccessEvent.AddListener(OnPowerUpSuccess);
        }
    }

    private void OnDisable()
    {
        if (powerUpRepeatableTrigger != null)
        {
            powerUpRepeatableTrigger.powerUpSuccessEvent.RemoveListener(OnPowerUpSuccess);
        }

        if (powerUpUniqueTrigger != null)
        {
            powerUpUniqueTrigger.PowerUpSuccessEvent.RemoveListener(OnPowerUpSuccess);
        }
    }
}
