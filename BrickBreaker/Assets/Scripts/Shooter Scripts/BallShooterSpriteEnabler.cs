using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallShooterSpriteEnabler : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private BallShooterHandler ballShooterHandler;
    [SerializeField] private GameManager gameManager;
    

    private void Awake()
    {
        _spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void EnableSprite()
    {
        _spriteRenderer.enabled = true;
    }

    private void DisableSprite()
    {
        _spriteRenderer.enabled = false;
    }

    public void OnEnable()
    {
        ballShooterHandler.StartShootBallEvent.AddListener(DisableSprite);
        gameManager.TurnEndEvent.AddListener(EnableSprite);
    }

    public void OnDisable()
    {
        ballShooterHandler.StartShootBallEvent.RemoveListener(DisableSprite);
        gameManager.TurnEndEvent.RemoveListener(EnableSprite);
    }
    
}
