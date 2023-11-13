using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEndTurnDestroyer : MonoBehaviour
{
    [SerializeField] private PowerUpRepeatableTrigger powerUpRepeatableTrigger;
    [SerializeField] private PowerUpUniqueTrigger powerUpUniqueTrigger;
    private GameManager _gameManager;
    private bool _isTriggered = false;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTurnEnd()
    {
        if (_isTriggered)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void OnPowerUpSuccess(BallHandler ballHandler)
    {
        _isTriggered = true;
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
        _gameManager.turnEndEvent.AddListener(OnTurnEnd);
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
        _gameManager.turnEndEvent.RemoveListener(OnTurnEnd);
    }
}
