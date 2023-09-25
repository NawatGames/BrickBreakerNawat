using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpContactDestroyer : MonoBehaviour
{
    [SerializeField] private PowerUpRepeatableTrigger powerUpRepeatableTrigger;


    private void OnPowerUpSuccess(BallHandler ballHandler)
    {
        Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        powerUpRepeatableTrigger.PowerUpSuccessEvent.AddListener(OnPowerUpSuccess);
    }

    private void OnDisable()
    {
        powerUpRepeatableTrigger.PowerUpSuccessEvent.RemoveListener(OnPowerUpSuccess);
    }
}
