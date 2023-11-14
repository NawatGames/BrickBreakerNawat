using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private float bonusMultiplier = 1.0f; 
    private int bonusIncrement = 50;

    private void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();
        UpdateBonusMultiplier(); 
    }

    public float GetBonusMultiplier()
    {
        return bonusMultiplier;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void UpdateBonusMultiplier()
    {
        int bonusIncrements = score / bonusIncrement;

        if (bonusIncrements > 0)
        {
            bonusMultiplier += bonusIncrements * 0.1f;
            bonusIncrement = (bonusIncrements + 1) * 50;
        }
    }
}