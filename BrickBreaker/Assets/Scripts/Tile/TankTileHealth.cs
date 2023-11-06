using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TankTileHealth : MonoBehaviour
{
    [SerializeField] private int numberOfHits = 5;
    [FormerlySerializedAs("TileHitEvent")] public UnityEvent<int> tileHitEvent;
    [FormerlySerializedAs("TilePrefab")] public GameObject tilePrefab;

    private void OnTileHit(int damage)
    {
        numberOfHits -= damage;
        if (numberOfHits <= 0)
        {
            ReplaceTile();
        }
    }
    void ReplaceTile()
    {
        Destroy(this.gameObject);
        GameObject newTile = Instantiate(tilePrefab, transform.position, transform.rotation);
    }
}
