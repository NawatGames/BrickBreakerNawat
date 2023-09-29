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

    TileDestroyer tileScript = tile.GetComponent<TileDestroyer>();
    BallDestroyer recieverScript = reciever.GetComponent<BallDestroyer>();
    PowerUpBallAdder powerUpScript = powerup.GetComponent<PowerUpBallAdder>();


    //adcionar ou alterar tags das paredes e obstáculos
    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Wall"){
            audioPlayerWall.Play();
            //Debug.Log("Parede");
        }
        
        if(tileScript){
            audioPlayerBrick.Play();
            //Debug.Log("Tijolo");
        }

        if(recieverScript){
            audioPlayerGround.Play();
            //Debug.Log("chao");
        }
    }

    public void OnTriggerEnter2D(Collider2D trigger){
        if(powerUpScript){
            audioPlayerPowerUp.Play();
            //Debug.Log("Upgrade");
        }
    }
    

}
