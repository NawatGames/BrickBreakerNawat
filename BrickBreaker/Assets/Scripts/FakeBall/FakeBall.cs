using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FakeBall : MonoBehaviour
{
    private Vector2 destination;
    [SerializeField] private float duration = 1f;
    private GameObject FirstFakeBall;
    private void Awake()
    {
        FirstFakeBall = GameObject.FindGameObjectWithTag("FirstFakeBall");
        destination = FirstFakeBall.transform.position;
    }

    private void Start()
    {
        transform.DOMove(destination, duration)
            .SetEase(Ease.OutQuad) // You can change the ease type as needed.
            .OnComplete(OnTweenComplete); // Optionally, call a method when the tween is complete.
    }

    private void OnTweenComplete()
    {
        Destroy(this.gameObject);
    }
}
