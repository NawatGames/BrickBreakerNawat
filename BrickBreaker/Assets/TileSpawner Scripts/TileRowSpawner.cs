using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRowSpawner : MonoBehaviour

{
    public GameObject[] tilePrefabs; // Lista de prefabs.
    public float spacing = 1.5f; //Espaços entre os tijolos
    public Transform spawnPoint; 

    void Start()
    {
        TileRowMover.RowMovedEvent+=SpawnRow;
    }

    public void SpawnRow()
    {
        Vector3 spawnPosition = transform.position; // Posição inicial de spawn.

        foreach (GameObject prefab in tilePrefabs)
        {
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            
            spawnPosition.x += spacing;
        }
    }
}