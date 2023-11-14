using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileHealthDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMeshPro;
    [SerializeField] private TileHealth _tileHealth;

    private void Awake()
    {
        _textMeshPro.text = _tileHealth.GetHealth().ToString();
    }

    private void OnTileHealthChanged(int health)
    {
        _textMeshPro.text = health.ToString();
    }

    private void OnEnable()
    {
        _tileHealth.TileHealthChangedEvent.AddListener(OnTileHealthChanged);
    }

    private void OnDisable()
    {
        _tileHealth.TileHealthChangedEvent.RemoveListener(OnTileHealthChanged);
    }
}
