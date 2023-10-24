using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void Start(){
        anim = gameObject.GetComponent<Animator>();
    }
    
    void OnCollisionEnter2D(Collision2D collision2D){
        if (collision2D.gameObject.CompareTag("Ball"))
        {
            anim.SetTrigger("Collision");
        }
    }
}