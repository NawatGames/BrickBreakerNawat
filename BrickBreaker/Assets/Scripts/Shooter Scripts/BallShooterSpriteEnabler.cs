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
        ballShooterHandler.startShootBallEvent.AddListener(DisableSprite);
        gameManager.turnEndEvent.AddListener(EnableSprite);
    }

    public void OnDisable()
    {
        ballShooterHandler.startShootBallEvent.RemoveListener(DisableSprite);
        gameManager.turnEndEvent.RemoveListener(EnableSprite);
    }
    
}
