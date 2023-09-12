using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileRowMover : MonoBehaviour
{
    public delegate void RowMover();
    public UnityEvent RowMovedEvent;
    public float tileSize = 1.0f; // Tamanho de um tijolo.


    void MoveTileRows()
    {
        GameObject[] tileRows = GameObject.FindGameObjectsWithTag("Tijolo");//Coloca a tag do objeto

        foreach (GameObject row in tileRows)
        {
            row.transform.Translate(Vector3.down * tileSize, Space.World);
        }

        // Dispara o evento RowMovedEvent.
        if (RowMovedEvent != null)
        {
            RowMovedEvent.Invoke();
        }
    }
}
