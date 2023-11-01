using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileHealthDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    [SerializeField] private TileHealth tileHealth;

    private void Awake()
    {
        textMeshPro.text = tileHealth.GetHealth().ToString();
    }

    private void OnTileHealthChanged(int health)
    {
        textMeshPro.text = health.ToString();
    }

    private void OnEnable()
    {
        tileHealth.tileHealthChangedEvent.AddListener(OnTileHealthChanged);
    }

    private void OnDisable()
    {
        tileHealth.tileHealthChangedEvent.RemoveListener(OnTileHealthChanged);
    }
}
