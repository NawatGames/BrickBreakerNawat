using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TileHealthDisplay : MonoBehaviour
{
    [FormerlySerializedAs("_textMeshPro")] [SerializeField] private TextMeshPro textMeshPro;
    [FormerlySerializedAs("_tileHealth")] [SerializeField] private TileHealth tileHealth;

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
