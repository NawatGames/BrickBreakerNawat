using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputFilter : MonoBehaviour
{
    [SerializeField] private RawInput rawInput;
    public Vector2 initialPosition;
    [SerializeField] private float angleClamp = 20f;
    
    public Vector2 AngleClamp(Vector2 position){
        float deltaX = position.x - initialPosition.x;
        float deltaY = position.y - initialPosition.y;
        float angle = Mathf.Atan2(deltaY, deltaX);
        float clampedAngle;
        if(angle < 0f){
            if (angle > -Mathf.PI / 2)
            {
                clampedAngle = angleClamp * Mathf.Deg2Rad;
            }
            else
            {
                clampedAngle = (180-angleClamp) * Mathf.Deg2Rad;
            }
        }
        else
        {
            clampedAngle = Mathf.Clamp(angle, angleClamp*Mathf.Deg2Rad, (180f-angleClamp)*Mathf.Deg2Rad);
        }
        Debug.Log(clampedAngle * Mathf.Rad2Deg);
        float x = Mathf.Cos(clampedAngle) * Math.Abs(deltaX);
        float y = Mathf.Sin(clampedAngle) * Math.Abs(deltaY);
        return new Vector2(x, y);
    }
    
    
    
    void SetInitialPosition(Vector2 position){
        initialPosition = position;
    }

    //calcular o valor de x
}