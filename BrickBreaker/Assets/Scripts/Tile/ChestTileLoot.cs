using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTileLoot : MonoBehaviour
{
    public GameObject powerUpPrefab; 
    public float spawnChance = 0.5f; 
    private void OnDestroy()
    {
        if (Random.value < spawnChance)
        {
            Instantiate(powerUpPrefab, transform.position, transform.rotation);
        }
    }
}