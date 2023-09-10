using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //Tudo nesse script � placeholder, n�o ser� usado depois
    public float for�aLan�amento = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Verifique se o bot�o esquerdo do mouse foi clicado.
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dire��o = (mousePos - transform.position).normalized; // Calcule a dire��o do lan�amento.

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(dire��o * for�aLan�amento, ForceMode2D.Impulse); // Aplique uma for�a impulsiva para lan�ar o objeto.
        }
    }

}
