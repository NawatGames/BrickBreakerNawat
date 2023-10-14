using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Mathf.Abs(_rigidbody2D.velocity.y) < 0.05f)
        {
            _rigidbody2D.AddForce(new Vector2(0, -0.2f), ForceMode2D.Impulse);
        }
    }
}
