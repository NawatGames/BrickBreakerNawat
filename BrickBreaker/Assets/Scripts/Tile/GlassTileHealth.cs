using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTileHealth : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(this.gameObject);  
    }
}
