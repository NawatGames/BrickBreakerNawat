using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class TileRowMover : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public delegate void RowMover();
    public UnityEvent RowMovedEvent;
    public float tileSize = 0.95f; // Tamanho de um tijolo.

    

    void MoveTileRows()
    {
        GameObject[] tileRows = GameObject.FindGameObjectsWithTag("Tile");//Coloca a tag do objeto

        foreach (GameObject row in tileRows)
        {
            if (row != null)
            {
                row.transform.DOMoveY(row.transform.position.y - tileSize, 0.5f);
            }
        }

        StartCoroutine(WaitForAnimation());

    }

    private void OnEnable()
    {
        gameManager.TurnEndEvent.AddListener(MoveTileRows);
    }

    private void OnDisable()
    {
        gameManager.TurnEndEvent.RemoveListener(MoveTileRows);
    }
    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        RowMovedEvent.Invoke();
    }
}
