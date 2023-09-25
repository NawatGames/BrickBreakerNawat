using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileRowSpawner : MonoBehaviour

{
    [SerializeField] private TileRowMover tileRowMover;
    [SerializeField] private GameManager gameManager;
    public float spacing = 1.5f; //Espaços entre os tijolos
    public Transform spawnPoint;
    [SerializeField] private LevelScriptableObject _level;
    public UnityEvent RowSpawnedEvent;
    public UnityEvent EndOfLevelEvent;
    
    void Start()
    {
        SpawnRow();
    }
    
    void OnEnable()
    {
        tileRowMover.RowMovedEvent.AddListener(SpawnRow);
    }

    void OnDisable()
    {
        tileRowMover.RowMovedEvent.RemoveListener(SpawnRow);
    }

    public void SpawnRow()
    {
        Vector2 spawnPosition = spawnPoint.position; // Posição inicial de spawn.
        
        if(gameManager.GetCurrentTurn() <= _level.levelRows.Length)
        {
            foreach (GameObject prefab in _level.levelRows[gameManager.GetCurrentTurn() - 1].rowObjects)
            {
                Instantiate(prefab, spawnPosition, Quaternion.identity);
            
                spawnPosition.x += spacing;
            }
        }
        
        else
        {
            EndOfLevelEvent.Invoke();
        }
        RowSpawnedEvent.Invoke();
    }
}