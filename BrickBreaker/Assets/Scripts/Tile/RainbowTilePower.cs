using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowTilePower : MonoBehaviour
{
    public GameObject glassTilePrefab; 
    private void OnDestroy()
    {
        TileCollisionHandler[] tiles = GameObject.FindObjectsOfType<TileCollisionHandler>();


        foreach (TileCollisionHandler tile in tiles)
        {
            var transform1 = tile.transform;
            Instantiate(glassTilePrefab, transform1.position, transform1.rotation);
            Destroy(tile);
        }
    }
}
