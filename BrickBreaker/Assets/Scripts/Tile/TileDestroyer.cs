using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroyer : MonoBehaviour
{
    [SerializeField] private TileHealth tileHealth;

    private void Awake()
    {
    }

    private void OnEnable()
    {
        tileHealth.noHealthEvent.AddListener(OnNoHealth);
    }

    private void OnDisable()
    {
        tileHealth.noHealthEvent.RemoveListener(OnNoHealth);
    }

    private void OnNoHealth()
    {
        Destroy(this.gameObject);
    }
}
