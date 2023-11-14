using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpBallAdder : MonoBehaviour
{
    [SerializeField] private PowerUpRepeatableTrigger powerUpRepeatableTrigger;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    
    private void OnPowerUpSuccess(BallHandler ballHandler){
        _gameManager.OnAdderTrigger();
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
