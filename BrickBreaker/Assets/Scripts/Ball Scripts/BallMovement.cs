using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private float speed;

    public void SetDirection(Vector2 direction)
    {
        rigidbody2D.velocity = direction.normalized * speed;

    }

}
