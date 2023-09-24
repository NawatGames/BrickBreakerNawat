using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooterTeleporter : MonoBehaviour
{
    [SerializeField] private FakeBallSpawner fakeBallSpawner;

    private void teleportShooter(Vector2 position)
    {
        this.gameObject.transform.position = position;
    }

    private void OnEnable()
    {
        fakeBallSpawner.SpawnFirstFakeBallEvent.AddListener(teleportShooter);
    }

    private void OnDisable()
    {
        fakeBallSpawner.SpawnFirstFakeBallEvent.RemoveListener(teleportShooter);
    }
}
