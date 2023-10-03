using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowTilePower : MonoBehaviour
{
    public GameObject glassTilePrefab; 
    private void OnDestroy()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");


        foreach (GameObject tile in tiles)
        {
            Instantiate(glassTilePrefab, tile.transform.position, tile.transform.rotation);
            Destroy(tile);
        }
    }
}
