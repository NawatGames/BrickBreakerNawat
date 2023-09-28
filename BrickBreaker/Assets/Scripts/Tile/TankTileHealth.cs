using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankTileHealth : MonoBehaviour
{
    [SerializeField] private int numberOfHits = 5;
    public UnityEvent<int> TileHitEvent;
    public GameObject TilePrefab;

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
        GameObject newTile = Instantiate(TilePrefab, transform.position, transform.rotation);
    }
}
