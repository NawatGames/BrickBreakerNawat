using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallPowerUp : MonoBehaviour
{
    [SerializeField] private GameObject fireBallPrefab;

    [SerializeField] private PowerUpUniqueTrigger powerUpUniqueTrigger;

    private void OnPowerUpSuccess(BallHandler ballHandler)
    {
        var fireBall = Instantiate(fireBallPrefab, ballHandler.transform.position, Quaternion.identity);
        fireBall.GetComponent<Transform>().parent = ballHandler.gameObject.transform;
        fireBall.GetComponent<FireBall>().SetBallHandler(ballHandler);
    }
    
    private void OnEnable()
    {
        powerUpUniqueTrigger.PowerUpSuccessEvent.AddListener(OnPowerUpSuccess);
    }
    
    private void OnDisable()
    {
        powerUpUniqueTrigger.PowerUpSuccessEvent.RemoveListener(OnPowerUpSuccess);
    }
}
