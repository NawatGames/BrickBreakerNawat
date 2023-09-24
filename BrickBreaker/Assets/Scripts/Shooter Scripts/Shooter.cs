using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject playerBall;
    [SerializeField] private BallShooterHandler ballShooterHandler;
    [SerializeField] private float absoluteVelocity = 10f;
    private ConvertVelocityVector _convertVelocityVector;

    public void InstanciarBolinha(Vector2 direcao)
    {
        GameObject playerBallclone = Instantiate(playerBall, this.gameObject.transform.position, Quaternion.identity);
        Rigidbody2D rb = playerBallclone.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = _convertVelocityVector.ConvertDirection(direcao, absoluteVelocity);
        }
    }

    private void Awake()
    {
        _convertVelocityVector = this.gameObject.AddComponent<ConvertVelocityVector>();
    }
    
    private void OnEnable()
    {
        ballShooterHandler.ShootBallEvent.AddListener(InstanciarBolinha);
    }

    private void OnDisable()
    {
        ballShooterHandler.ShootBallEvent.RemoveListener(InstanciarBolinha);
    }
    
    
}