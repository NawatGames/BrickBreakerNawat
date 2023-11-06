using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TileDestroyer : MonoBehaviour
{
    [FormerlySerializedAs("_tileHealth")] [SerializeField] private TileHealth tileHealth;
    private AddScore _addScore;
    

    private void Awake()
    {
        _addScore = GameObject.FindObjectOfType<AddScore>();
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
        _addScore.AddScoreEvent.Invoke(1);
        Destroy(this.gameObject);
        
    }
}
