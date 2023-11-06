using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class BallShooterHandler : MonoBehaviour
{
    private int _maxBallCount;
    [SerializeField] private float shootingDelay = 0.1f;
    // Start is called before the first frame update
    [SerializeField] private InputFilter inputFilter;
    [SerializeField] private GameManager gameManager;
    [FormerlySerializedAs("StartShootBallEvent")] public UnityEvent startShootBallEvent;
    [FormerlySerializedAs("ShootBallEvent")] public UnityEvent<Vector2> shootBallEvent;
    [FormerlySerializedAs("EndShootBallEvent")] public UnityEvent endShootBallEvent;
    
    private void OnFilteredInput(Vector2 direction)
    {
        
        _maxBallCount = gameManager.GetMaxBallCount();
        StartCoroutine(BallSpawnerIterator(direction));
    }

    private IEnumerator BallSpawnerIterator(Vector2 direction)
    {
        startShootBallEvent.Invoke();
        for(int i = 0; i < _maxBallCount; i++)
        {
            shootBallEvent.Invoke(direction);
            yield return new WaitForSeconds(shootingDelay);
        }
        endShootBallEvent.Invoke();
    }
    
    private void OnEnable()
    {
        inputFilter.filteredInputEvent.AddListener(OnFilteredInput);
    }

    private void OnDisable()
    {
        inputFilter.filteredInputEvent.RemoveListener(OnFilteredInput);
    }
}
