using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBreakAnimation : MonoBehaviour
{
    [SerializeField] private TileHealth _tileHealth;
    private void OnEnable()
    {
        _tileHealth.NoHealthEvent.AddListener(OnNoHealth);
    }

    private void OnDisable()
    {
        _tileHealth.NoHealthEvent.RemoveListener(OnNoHealth);
    }

    [SerializeField] GameObject prefab;

    private void OnNoHealth()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

}
