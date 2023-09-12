using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundFireball : MonoBehaviour
{
    //script separado para o upgrade de bola de fogo
    //note to self: no caso de mais de um som para a bola de fogo, replicar código

    public AudioSource audioPlayerFire;

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Wall"){
            audioPlayerFire.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
