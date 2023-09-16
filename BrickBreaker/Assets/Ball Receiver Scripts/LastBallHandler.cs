using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LastBallHandler : MonoBehaviour
{
    public UnityEvent EndTurnEvent; 
    
    void Start()
    {
        GameObject[] bolinhas = GameObject.FindGameObjectsWithTag("Bolinha");
        
        if (bolinhas.Length == 1)
        {
            EndTurnEvent.Invoke();
        }
    }
}