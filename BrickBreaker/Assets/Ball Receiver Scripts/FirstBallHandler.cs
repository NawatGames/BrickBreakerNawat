using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class FirstBallHandler : MonoBehaviour
{
    [SerializeField] private TurnManager turnManager;
    public bool isFirstFakeBall;
    public GameObject FirstFakeBall;

    private void Update()
    {
        ResetFirstFakeBall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == FirstFakeBall) 
        {
            isFirstFakeBall = false;
            Instantiate(FirstFakeBall, new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
        }
    }

    private void ResetFirstFakeBall()
    {
        if (turnManager.TurnEndEvent!=null)
        {
            isFirstFakeBall = true;
        }
    }

}