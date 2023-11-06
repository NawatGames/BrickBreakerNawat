using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooterTeleporter : MonoBehaviour
{
    [SerializeField] private FakeBallSpawner fakeBallSpawner;

    private void TeleportShooter(Vector2 position)
    {
        this.gameObject.transform.position = position;
    }

    private void OnEnable()
    {
        fakeBallSpawner.spawnFirstFakeBallEvent.AddListener(TeleportShooter);
    }

    private void OnDisable()
    {
        fakeBallSpawner.spawnFirstFakeBallEvent.RemoveListener(TeleportShooter);
    }
}
