using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] private PowerUpUniqueTrigger powerUpUniqueTrigger;
    [SerializeField] private PowerUpRepeatableTrigger powerUpRepeatableTrigger;
    [SerializeField] private PowerUpEndTurnDestroyer powerUpEndTurnDestroyer;
    [SerializeField] private PowerUpContactDestroyer powerUpContactDestroyer;
    [SerializeField] private PowerUpBallAdder powerUpBallAdder;
    [SerializeField] private FireBallPowerUp fireBallPowerUp;
    [SerializeField] private PowerUpBallAdder powerUpBallAdder1;
    
}
