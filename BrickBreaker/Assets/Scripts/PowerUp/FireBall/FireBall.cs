using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireBall : MonoBehaviour
{
    private BallHandler _ballHandler;
    [SerializeField] private int fireBallDamage = 2;

    private void OnDisable()
    {
        _ballHandler.GetComponent<BallCollisionHandler>().TileCollisionEvent.RemoveListener(OnCollision);
        _ballHandler.GetComponent<BallCollisionHandler>().WallCollisionEvent.RemoveListener(OnCollision);
    }

    private void OnCollision(Collision2D collision2D)
    {
        _ballHandler.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        _ballHandler.ballDamage.SetDamage(1);
        Destroy(this.gameObject);
    }

    private void OnCollision()
    {
        _ballHandler.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        _ballHandler.ballDamage.SetDamage(1);
        Destroy(this.gameObject);
    }

    public void SetBallHandler(BallHandler ballHandler)
    {
        _ballHandler = ballHandler;
        _ballHandler.ballDamage.SetDamage(fireBallDamage);
        _ballHandler.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        _ballHandler.GetComponent<BallCollisionHandler>().TileCollisionEvent.AddListener(OnCollision);
        _ballHandler.GetComponent<BallCollisionHandler>().WallCollisionEvent.AddListener(OnCollision);
    }
}
