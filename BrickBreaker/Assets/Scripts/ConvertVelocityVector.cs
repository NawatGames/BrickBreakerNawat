using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertVelocityVector : MonoBehaviour
{
    public Vector2 ConvertDirection(Vector2 direction, float absoluteVelocity)
    {   
        float x = direction.x;
        float y = direction.y;
        float angle = Mathf.Atan2(y, x);
        float xVelocity = absoluteVelocity * Mathf.Cos(angle);
        float yVelocity = absoluteVelocity * Mathf.Sin(angle);
        Vector2 velocity = new Vector2(xVelocity, yVelocity);
        return velocity;
    }
}
