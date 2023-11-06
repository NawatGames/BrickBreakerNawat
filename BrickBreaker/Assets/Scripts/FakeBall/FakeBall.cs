using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FakeBall : MonoBehaviour
{
    private Vector2 _destination;
    [SerializeField] private float tweenSpeed = 3f;
    private GameObject _firstFakeBall;
    private void Awake()
    {
        
        _firstFakeBall = GameObject.FindGameObjectWithTag("FirstFakeBall");
        _destination = _firstFakeBall.transform.position;
    }

    private void Start()
    {
        transform.DOMove(_destination, Mathf.Abs(_destination.x - this.transform.position.x)/ tweenSpeed)
            .SetEase(Ease.OutQuad) // You can change the ease type as needed.
            .OnComplete(OnTweenComplete); // Optionally, call a method when the tween is complete.
    }

    private void OnTweenComplete()
    {
    }
}
