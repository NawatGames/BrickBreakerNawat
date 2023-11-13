using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideBall : MonoBehaviour
{
    private BallHandler _ballHandler;
    [SerializeField] private Material divideBallMaterial;
    private Material _defaultMaterial;
    [SerializeField] private float divisionForce = 5f;
    [SerializeField] private Vector2 divisionDirection = Vector2.one;
    [SerializeField] private GameObject dividedBall;

    private void OnDisable()
    {
        _ballHandler.GetComponent<BallCollisionHandler>().TileCollisionEvent.RemoveListener(OnCollision);
        _ballHandler.GetComponent<BallCollisionHandler>().WallCollisionEvent.RemoveListener(OnCollision);
    }

    private void OnCollision(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Tile"))
        {
            // Crie duas novas bolas a partir do prefab
            GameObject novaBola1 = Instantiate(dividedBall, transform.position, Quaternion.identity);
            GameObject novaBola2 = Instantiate(dividedBall, transform.position, Quaternion.identity);

            // Aplique forças para separar as bolas
            Rigidbody2D rb1 = novaBola1.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = novaBola2.GetComponent<Rigidbody2D>();

            rb1.velocity = divisionForce * divisionDirection;
            rb2.velocity = -divisionForce * divisionDirection;

            // Destrua a bola original
            Destroy(gameObject);
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
        _ballHandler.gameObject.GetComponent<SpriteRenderer>().material = divideBallMaterial;
        _ballHandler.GetComponent<BallCollisionHandler>().TileCollisionEvent.AddListener(OnCollision);
        _ballHandler.GetComponent<BallCollisionHandler>().WallCollisionEvent.AddListener(OnCollision);
    }
}
