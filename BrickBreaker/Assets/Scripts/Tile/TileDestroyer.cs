using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroyer : MonoBehaviour
{
    [SerializeField] private TileHealth _tileHealth;

    private void Awake()
    {
    }

    private void OnEnable()
    {
        _tileHealth.NoHealthEvent.AddListener(OnNoHealth);
    }

    private void OnDisable()
    {
        _tileHealth.NoHealthEvent.RemoveListener(OnNoHealth);
    }

    private void OnNoHealth()
    {
        Destroy(this.gameObject);
    }
}
