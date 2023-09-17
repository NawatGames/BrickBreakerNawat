using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LineRaycast : MonoBehaviour
{
    public UnityEvent OnHitEvent;
    private bool _isHit = false;
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.up * (-20f), out RaycastHit hit))
        {
            _isHit = true;
            Debug.DrawRay(transform.position, transform.up * (-20f), Color.green);
        }
        else
        {
            if (_isHit)
            {
                Debug.Log("Pass!");
                OnHitEvent.Invoke();
                _isHit = false;
            }
        }
    }
}
