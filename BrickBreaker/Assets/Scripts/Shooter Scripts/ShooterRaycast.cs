using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShooterRaycast : MonoBehaviour
{// The starting point of the raycast

    public Vector2 GetRaycastHitPosition(Vector2 direction, Vector2 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, direction, Mathf.Infinity, LayerMask.GetMask("Default") | LayerMask.GetMask("Tile"));
        // Check if the ray hits something
        if (hit.collider != null)
        {
            // The ray hit something, and hit.point contains the position of the hit
            Vector2 hitPosition = hit.point;
            // Do something with the hitPosition (e.g., print it)
            return hitPosition;
        }
        return direction;
    }
}
