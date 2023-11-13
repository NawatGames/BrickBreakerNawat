using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PowerUpUniqueTrigger : MonoBehaviour
{
    [FormerlySerializedAs("powerUpSuccessEvent")] public UnityEvent<BallHandler> PowerUpSuccessEvent;
    [FormerlySerializedAs("PowerUpFailEvent")] public UnityEvent powerUpFailEvent;
    private BallHandler[] _ballList;
    private bool _isTriggered = false;

    private void Awake()
    {
        _ballList = new BallHandler[0];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        BallHandler ballHandler = other.GetComponent<BallHandler>();
        if (ballHandler != null)
        {
            _isTriggered = false;
            foreach (var ball in _ballList)
            {
                if (ball == ballHandler)
                {
                    _isTriggered = true;
                }
            }

            if (!_isTriggered)
            {
                AddBallToList(ballHandler);
                PowerUpSuccessEvent.Invoke(ballHandler);
            }
            else
            {
                powerUpFailEvent.Invoke();
            }
        }
    }

    private void AddBallToList(BallHandler ball)
    {
        BallHandler[] tempBallList = new BallHandler[_ballList.Length + 1];
        for (int i = 0; i < _ballList.Length; i++)
        {
            tempBallList[i] = _ballList[i];
        }

        tempBallList[tempBallList.Length - 1] = ball;
        _ballList = tempBallList;
    }
}
