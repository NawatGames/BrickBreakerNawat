using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroBallPowerUp : MonoBehaviour
{
    [SerializeField] private GameObject electroBallPrefab;
    
    [SerializeField] private PowerUpUniqueTrigger powerUpUniqueTrigger;

    private void OnPowerUpSuccess(BallHandler ballHandler)
    {
        var electroBall = Instantiate(electroBallPrefab, ballHandler.transform.position, Quaternion.identity);
        electroBall.GetComponent<Transform>().parent = ballHandler.gameObject.transform;
        electroBall.GetComponent<ElectroBall>().SetBallHandler(ballHandler);
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
