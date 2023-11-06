using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TileRowSpawner : MonoBehaviour

{
    [SerializeField] private TileRowMover tileRowMover;
    [SerializeField] private GameManager gameManager;
    public float spacing = 1.5f; //Espaços entre os tijolos
    public Transform spawnPoint;
    [FormerlySerializedAs("_level")] [SerializeField] private LevelScriptableObject level;
    [FormerlySerializedAs("RowSpawnedEvent")] public UnityEvent rowSpawnedEvent;
    [FormerlySerializedAs("EndOfLevelEvent")] public UnityEvent endOfLevelEvent;
    
    void Start()
    {
        SpawnRow();
    }
    
    void OnEnable()
    {
        tileRowMover.rowMovedEvent.AddListener(SpawnRow);
    }

    void OnDisable()
    {
        tileRowMover.rowMovedEvent.RemoveListener(SpawnRow);
    }

    public void SpawnRow()
    {
        Vector2 spawnPosition = spawnPoint.position; // Posição inicial de spawn.
        
        if(gameManager.GetCurrentTurn() <= level.levelRows.Length)
        {
            foreach (GameObject prefab in level.levelRows[gameManager.GetCurrentTurn() - 1].rowObjects)
            {
                Instantiate(prefab, spawnPosition, Quaternion.identity);
            
                spawnPosition.x += spacing;
            }
        }
        
        else
        {
            endOfLevelEvent.Invoke();
        }
        rowSpawnedEvent.Invoke();
    }
}