using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElectroBall : MonoBehaviour
{
    private BallHandler _ballHandler;
    [SerializeField] private float electroAray = 1f;
    [SerializeField] private ElectroAnimation electroAnimation;
    [SerializeField] private Material electroBallMaterial;
    private Material _defaultMaterial;

    private void OnDisable()
    {
        _ballHandler.GetComponent<BallCollisionHandler>().TileCollisionEvent.RemoveListener(OnCollision);
        _ballHandler.GetComponent<BallCollisionHandler>().WallCollisionEvent.RemoveListener(OnCollision);
    }

    private void OnCollision(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Tile"))
        {
            Vector2 collisionPoint = collision2D.contacts[0].point;
            /*electroAnimation.DrawCircle(collisionPoint, electroAray);*/
            Collider2D[] objetosNoRaio = Physics2D.OverlapCircleAll(collisionPoint, electroAray);
            foreach (Collider2D objetoNoRaio in objetosNoRaio)
            {  
                TileHealth health = objetoNoRaio.GetComponent<TileHealth>();
                if (health != null)
                {
                    health.SubtractHealth(_ballHandler.ballDamage.GetDamage(), null);
                }
            }
        }
        _ballHandler.ballDamage.SetDamage(1);
        _ballHandler.gameObject.GetComponent<SpriteRenderer>().material = _defaultMaterial;
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
        _defaultMaterial = _ballHandler.GetComponent<SpriteRenderer>().material;
        _ballHandler.gameObject.GetComponent<SpriteRenderer>().material = electroBallMaterial;
        _ballHandler.GetComponent<BallCollisionHandler>().TileCollisionEvent.AddListener(OnCollision);
        _ballHandler.GetComponent<BallCollisionHandler>().WallCollisionEvent.AddListener(OnCollision);
    }
}
