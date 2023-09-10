using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //Tudo nesse script é placeholder, não será usado depois
    public float forçaLançamento = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Verifique se o botão esquerdo do mouse foi clicado.
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direção = (mousePos - transform.position).normalized; // Calcule a direção do lançamento.

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(direção * forçaLançamento, ForceMode2D.Impulse); // Aplique uma força impulsiva para lançar o objeto.
        }
    }

}
