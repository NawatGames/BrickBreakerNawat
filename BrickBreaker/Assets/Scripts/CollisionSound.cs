using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{

    public AudioSource audioPlayerWall;
    public AudioSource audioPlayerBrick;
    public AudioSource audioPlayerGround;
    public AudioSource audioPlayerPowerUp;

    //colocar script no prefab das bolinhas

    //adcionar ou alterar tags das paredes e obstáculos
    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Wall"){
            audioPlayerWall.Play();
            //Debug.Log("Parede");
        }
        
        if(collision.gameObject.tag == "Brick"){
            audioPlayerBrick.Play();
            //Debug.Log("Tijolo");
        }

        if(collision.gameObject.tag == "Ground"){
            audioPlayerGround.Play();
            //Debug.Log("chao");
        }
    }

    public void OnTriggerEnter2D(Collider2D trigger){
        if(trigger.gameObject.tag == "PowerUp"){
            audioPlayerPowerUp.Play();
            //Debug.Log("Upgrade");
        }
    }
    

}
