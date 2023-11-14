using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FakeBall : MonoBehaviour
{
    private Vector2 destination;
    [SerializeField] private float tweenSpeed = 3f;
    private GameObject FirstFakeBall;
    private void Awake()
    {
        
        FirstFakeBall = GameObject.FindGameObjectWithTag("FirstFakeBall");
        destination = FirstFakeBall.transform.position;
    }

    private void Start()
    {
        transform.DOMove(destination, Mathf.Abs(destination.x - this.transform.position.x)/ tweenSpeed)
            .SetEase(Ease.OutQuad) // You can change the ease type as needed.
            .OnComplete(OnTweenComplete); // Optionally, call a method when the tween is complete.
    }

    private void OnTweenComplete()
    {
    }
}
