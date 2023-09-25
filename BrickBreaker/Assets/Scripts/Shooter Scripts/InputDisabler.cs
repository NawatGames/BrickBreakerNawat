using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class InputDisabler : MonoBehaviour
{
    [SerializeField] private GameObject inputManager;
    [SerializeField] private BallShooterHandler ballShooterHandler;
    [SerializeField] private TileRowSpawner tileRowSpawner;

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
        tileRowSpawner.RowSpawnedEvent.AddListener(EnableInputManager);
    }

    private void OnDisable()
    {
        ballShooterHandler.StartShootBallEvent.RemoveListener(DisableInputManager);
        tileRowSpawner.RowSpawnedEvent.RemoveListener(EnableInputManager);
    }
}
