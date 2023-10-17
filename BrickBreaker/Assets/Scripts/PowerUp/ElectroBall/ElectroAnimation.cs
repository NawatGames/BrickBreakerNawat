using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroAnimation : MonoBehaviour
{
    [SerializeField] private int segments = 64;
    [SerializeField] private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;
    }

    public void DrawCircle(Vector2 position, float radius)
    {
        float angle = 0f;
        float angleIncrement = 360f / segments;

        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lineRenderer.SetPosition(i, new Vector3(x+position.x,y+position.y, 0f));
            
            angle += angleIncrement;
        }
    }
}
