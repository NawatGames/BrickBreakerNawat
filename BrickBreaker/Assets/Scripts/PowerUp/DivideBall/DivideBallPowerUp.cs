using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideBallPowerUp : MonoBehaviour
{
    [SerializeField] private GameObject divideBallPrefab;

    [SerializeField] private PowerUpUniqueTrigger powerUpUniqueTrigger;

    private void OnPowerUpSuccess(BallHandler ballHandler)
    {
        var divideBall = Instantiate(divideBallPrefab, ballHandler.transform.position, Quaternion.identity);
        divideBall.GetComponent<Transform>().parent = ballHandler.gameObject.transform;
        divideBall.GetComponent<DivideBall>().SetBallHandler(ballHandler);
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