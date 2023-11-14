using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LastFakeBall : MonoBehaviour
{
    private Vector2 destination;
    [SerializeField] private float tweenSpeed = 3f;
    private GameObject FirstFakeBall;
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        FirstFakeBall = GameObject.FindGameObjectWithTag("FirstFakeBall");
        if (FirstFakeBall != null)
        {
            destination = FirstFakeBall.transform.position;
        }
    }

    private void Start()
    {
        transform.DOMove(destination, Mathf.Abs(destination.x - this.transform.position.x)/ tweenSpeed)
            .SetEase(Ease.OutQuad) // You can change the ease type as needed.
            .OnComplete(OnTweenComplete); // Optionally, call a method when the tween is complete.
    }

    private void OnTweenComplete()
    {
        _gameManager.TurnEndEvent.Invoke();
        GameObject[] fakeBallList = GameObject.FindGameObjectsWithTag("FakeBall");
        foreach (GameObject fakeBall in fakeBallList)
        {
            Destroy(fakeBall);
        }
    }
}
