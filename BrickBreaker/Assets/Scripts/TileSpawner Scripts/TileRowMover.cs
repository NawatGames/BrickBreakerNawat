using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using Unity.VisualScripting;

public class TileRowMover : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public delegate void RowMover();
    public UnityEvent RowMovedEvent;
    public float tileSize = 1.0f; // Tamanho de um tijolo
    
    

    void MoveTileRows()
    {
        TileHealth[] tileRows = GameObject.FindObjectsOfType<TileHealth>();

        foreach (TileHealth row in tileRows)
        {
            if (row != null)
            {
                row.gameObject.transform.DOMoveY(row.gameObject.transform.position.y - tileSize, 0.5f);
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
