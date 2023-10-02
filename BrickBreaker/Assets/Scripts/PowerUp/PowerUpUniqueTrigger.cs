using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUpUniqueTrigger : MonoBehaviour
{
    public UnityEvent<BallHandler> PowerUpSuccessEvent;
    public UnityEvent PowerUpFailEvent;
    private BallHandler[] _ballList;
    private bool _isTriggered = false;

    private void Awake()
    {
        _ballList = new BallHandler[0];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        BallHandler _ballHandler = other.GetComponent<BallHandler>();
        if (_ballHandler != null)
        {
            _isTriggered = false;
            foreach (var ball in _ballList)
            {
                if (ball == _ballHandler)
                {
                    _isTriggered = true;
                }
            }

            if (!_isTriggered)
            {
                AddBallToList(_ballHandler);
                PowerUpSuccessEvent.Invoke(_ballHandler);
            }
            else
            {
                PowerUpFailEvent.Invoke();
            }
        }
    }

    private void AddBallToList(BallHandler ball)
    {
        BallHandler[] _tempBallList = new BallHandler[_ballList.Length + 1];
        for (int i = 0; i < _ballList.Length; i++)
        {
            _tempBallList[i] = _ballList[i];
        }

        _tempBallList[_tempBallList.Length - 1] = ball;
        _ballList = _tempBallList;
    }
}
