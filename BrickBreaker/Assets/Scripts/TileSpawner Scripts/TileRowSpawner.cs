using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRowSpawner : MonoBehaviour

{
    private TileRowMover _tileRowMover;
    public GameObject[] tilePrefabs; // Lista de prefabs.
    public float spacing = 1.5f; //Espaços entre os tijolos
    public Transform spawnPoint;

    void Awake()
    {
        _tileRowMover = this.gameObject.GetComponent<TileRowMover>();
    }
    void OnEnable()
    {
        _tileRowMover.RowMovedEvent.AddListener(SpawnRow);
    }

    void OnDisable()
    {
        _tileRowMover.RowMovedEvent.RemoveListener(SpawnRow);
    }

    public void SpawnRow()
    {
        Vector2 spawnPosition = transform.position; // Posição inicial de spawn.

        foreach (GameObject prefab in tilePrefabs)
        {
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            
            spawnPosition.x += spacing;
        }
    }
}