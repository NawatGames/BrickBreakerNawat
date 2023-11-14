using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddScore : MonoBehaviour
{
    public int pointsPerBreak = 10;
    public UnityEvent<int> AddScoreEvent;

    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void OnAddScore(int tileHealth)
    {
        _scoreManager.IncreaseScore(CalculatePoints(tileHealth));
    }

    private int CalculatePoints(int tileHealth)
    {
        
        return Mathf.RoundToInt(pointsPerBreak * _scoreManager.GetBonusMultiplier());
    }

    private void OnEnable()
    {
        AddScoreEvent.AddListener(OnAddScore);
    }

    private void OnDisable()
    {
        AddScoreEvent.RemoveListener(OnAddScore);
    }
}