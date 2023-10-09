using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTilePower : MonoBehaviour
{
    private void OnDestroy()
    {
        TileCollisionHandler[] tiles = TileCollisionHandler.FindObjectsOfType<TileCollisionHandler>();

        foreach (TileCollisionHandler tile in tiles)
        {
            Destroy(tile);
        }
    }
}
