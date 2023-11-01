using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankTileHealth : MonoBehaviour
{
    [SerializeField] private int numberOfHits = 5;
    public UnityEvent<int> tileHitEvent;
    public GameObject tilePrefab;

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
