using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject playerBall;
    [SerializeField] private float absoluteVelocity = 10f;
    private ConvertVelocityVector _convertVelocityVector;

    public void InstantiateBall(Vector2 direcao)
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
}