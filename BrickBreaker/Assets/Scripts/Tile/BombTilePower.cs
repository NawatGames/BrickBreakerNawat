using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTilePower : MonoBehaviour
{
    private void OnDestroy()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

        foreach (GameObject tile in tiles)
        {
            Destroy(tile);
        }
    }
}
