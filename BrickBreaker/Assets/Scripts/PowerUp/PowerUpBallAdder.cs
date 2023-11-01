using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpBallAdder : MonoBehaviour
{
    [SerializeField] private PowerUpRepeatableTrigger powerUpRepeatableTrigger;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    
    private void OnPowerUpSuccess(BallHandler ballHandler){
        gameManager.OnAdderTrigger();
    }
    
    private void OnEnable()
    {
        powerUpRepeatableTrigger.powerUpSuccessEvent.AddListener(OnPowerUpSuccess);
    }

    private void OnDisable()
    {
        powerUpRepeatableTrigger.powerUpSuccessEvent.RemoveListener(OnPowerUpSuccess);
    }
    
}
