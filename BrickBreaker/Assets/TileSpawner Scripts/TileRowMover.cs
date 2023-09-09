using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRowMover : MonoBehaviour
{
    public delegate void RowMover();
    public static event RowMover RowMovedEvent;
    public float tileSize = 1.0f; // Tamanho de um tijolo.

    void Start()
    {
       TurnEndEvent.TurnEnded += MoveTileRows;
    }

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
            RowMovedEvent();
        }
    }
}
