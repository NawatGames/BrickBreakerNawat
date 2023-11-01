using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMessage : MonoBehaviour
{
    [SerializeField] private WinCondition winCondition;
    
    private void OnWin()
    {
        SceneManager.LoadScene(2);
    }
    
    private void OnEnable()
    {
        winCondition.winEvent.AddListener(OnWin);
    }

    private void OnDisable()
    {
        winCondition.winEvent.RemoveListener(OnWin);
    }
}
