using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputDisabler : MonoBehaviour
{
    [SerializeField] private GameObject inputManager;
    [SerializeField] private BallShooterHandler ballShooterHandler;

    private void DisableInputManager()
    {
        inputManager.SetActive(false);
    }

    private void EnableInputManager()
    {
        inputManager.SetActive(true);
    }
    private void OnEnable()
    {
        ballShooterHandler.StartShootBallEvent.AddListener(DisableInputManager);
    }

    private void OnDisable()
    {
        ballShooterHandler.StartShootBallEvent.RemoveListener(DisableInputManager);
    }
}
