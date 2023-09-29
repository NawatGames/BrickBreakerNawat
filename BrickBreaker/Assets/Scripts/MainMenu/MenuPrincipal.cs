using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField]private int dificuldade = 0;
   public void JogarJogo()
    {
        if(dificuldade == 0)
        {
            SceneManager.LoadScene(0);
        }
        else if(dificuldade== 1)
        {
            SceneManager.LoadScene(1);
        }
        else if(dificuldade == 2)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void SairJogo()
    {
        Application.Quit();
    }
    public void FacilJogo()
    {
        dificuldade = 0;
    }
    public void MedioJogo()
    {
        dificuldade = 1;
    }
    public void DificilJogo()
    {
        dificuldade = 2;
    }
}
