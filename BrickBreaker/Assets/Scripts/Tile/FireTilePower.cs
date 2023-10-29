using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTilePower : MonoBehaviour
{
    public GameObject tilePrefab; 
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.GetComponent<BallHandler>() != null)
        {
            Destroy(collision.gameObject);
            Instantiate(tilePrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
