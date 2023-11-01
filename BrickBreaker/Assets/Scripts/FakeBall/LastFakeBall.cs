using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LastFakeBall : MonoBehaviour
{
    private Vector2 _destination;
    [SerializeField] private float tweenSpeed = 3f;
    private GameObject _firstFakeBall;
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _firstFakeBall = GameObject.FindGameObjectWithTag("FirstFakeBall");
        if (_firstFakeBall != null)
        {
            _destination = _firstFakeBall.transform.position;
        }
    }

    private void Start()
    {
        transform.DOMove(_destination, Mathf.Abs(_destination.x - this.transform.position.x)/ tweenSpeed)
            .SetEase(Ease.OutQuad) // You can change the ease type as needed.
            .OnComplete(OnTweenComplete); // Optionally, call a method when the tween is complete.
    }

    private void OnTweenComplete()
    {
        _gameManager.turnEndEvent.Invoke();
        GameObject[] fakeBallList = GameObject.FindGameObjectsWithTag("FakeBall");
        foreach (GameObject fakeBall in fakeBallList)
        {
            Destroy(fakeBall);
        }
    }
}
