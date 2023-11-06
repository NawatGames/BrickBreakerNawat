using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomExplosion : MonoBehaviour
{
    private SpriteRenderer _renderer;
    
    [SerializeField] private float initialTime = 0.5f;
    [SerializeField] private float finalTime = 1f;
    [SerializeField] private float speed = 1f;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private IEnumerator Start()
    {

        var neonMaterial = _renderer.material;
        var currentTime = initialTime;
        neonMaterial.SetFloat("_CustomTime", currentTime);
        
        while (true)
        {
            yield return null;
            currentTime += Time.deltaTime * speed;
            neonMaterial.SetFloat("_CustomTime", currentTime);
            if (currentTime >= finalTime)
            {
                break;
                Destroy(gameObject);
            }
        }
    }
}