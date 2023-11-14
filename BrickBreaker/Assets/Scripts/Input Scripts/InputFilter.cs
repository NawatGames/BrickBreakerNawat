using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InputFilter : MonoBehaviour
{
    [SerializeField] private RawInput rawInput;
    public Vector2 initialPosition;
    [SerializeField] private float angleClamp = 20f;
    public UnityEvent<Vector2> FilteredInputEvent;
    private bool isDragging = false;
    
    public Vector2 AngleClamp(Vector2 position){
        {
            if (Math.Abs(position.x - initialPosition.x) < 0.001 && position.y - initialPosition.y < 0)
            {
                return new Vector2(Mathf.Cos(angleClamp * Mathf.Deg2Rad), Mathf.Sin(angleClamp * Mathf.Deg2Rad));
            }
            else
            {
                float deltaX = position.x - initialPosition.x;
                float deltaY = position.y - initialPosition.y;
                float angle = Mathf.Atan2(deltaY, deltaX);
                float clampedAngle;
                float x;
                float y;
                if(angle < angleClamp * Mathf.Deg2Rad){
                    if (angle > -Mathf.PI / 2)
                    {
                        clampedAngle = angleClamp * Mathf.Deg2Rad;
                        x = deltaX * Mathf.Cos(clampedAngle);
                        y = x * Mathf.Tan(clampedAngle);
                    }
                    else
                    {
                        clampedAngle = (180-angleClamp) * Mathf.Deg2Rad;
                        x = -deltaX * Mathf.Cos(clampedAngle);
                        y = x * Mathf.Tan(clampedAngle);
                    }
                }
                else
                {
                    if (angle > (180 - angleClamp) * Mathf.Deg2Rad)
                    {
                        clampedAngle = (180-angleClamp) * Mathf.Deg2Rad;
                        x = -deltaX * Mathf.Cos(clampedAngle);
                        y = x * Mathf.Tan(clampedAngle);
                    }
                    else
                    {
                        return position - initialPosition;
                    }
                }
                Debug.Log(new Vector2(x, y));
                return new Vector2(x, y);
            }
        }
    }

    void OnEnable()
    {
        rawInput.worldspacePointerUpEvent.AddListener(OnWorldspacePointerUp);
        rawInput.worldspacePointerDragEvent.AddListener(OnWorldSpaceDrag);
    } 

    void OnDisable()
    {
        rawInput.worldspacePointerUpEvent.RemoveListener(OnWorldspacePointerUp);
        rawInput.worldspacePointerDragEvent.RemoveListener(OnWorldSpaceDrag);
    }
    
    private void OnWorldspacePointerUp(Vector2 direction)
    {
        if (isDragging)
        {
            isDragging = false;
            FilteredInputEvent.Invoke(AngleClamp(direction));
        }
    }

    public void SetInitialPosition(Vector2 position){
        initialPosition = position;
    }

    private void OnWorldSpaceDrag(Vector2 empty)
    {
        isDragging = true;
    }
    
}