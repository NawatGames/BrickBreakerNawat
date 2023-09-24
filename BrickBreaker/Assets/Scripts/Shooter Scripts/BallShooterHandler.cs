using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class BallShooterHandler : MonoBehaviour
{
    private int _maxBallCount = 3;
    [SerializeField] private float shootingDelay = 0.1f;
    // Start is called before the first frame update
    [SerializeField] private InputFilter inputFilter;
    public UnityEvent StartShootBallEvent;
    public UnityEvent<Vector2> ShootBallEvent;
    public UnityEvent EndShootBallEvent;

    private void OnFilteredInput(Vector2 direction)
    {
        StartCoroutine(BallSpawnerIterator(direction));
    }

    private IEnumerator BallSpawnerIterator(Vector2 direction)
    {
        StartShootBallEvent.Invoke();
        for(int i = 0; i < _maxBallCount; i++)
        {
            ShootBallEvent.Invoke(direction);
            yield return new WaitForSeconds(shootingDelay);
        }
        EndShootBallEvent.Invoke();
    }
    
    private void OnEnable()
    {
        inputFilter.FilteredInputEvent.AddListener(OnFilteredInput);
    }

    private void OnDisable()
    {
        inputFilter.FilteredInputEvent.RemoveListener(OnFilteredInput);
    }
}
