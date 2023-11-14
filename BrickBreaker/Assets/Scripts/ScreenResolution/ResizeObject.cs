using UnityEngine;

public class ResizeObject : MonoBehaviour
{
    private Vector3 initialScale;
    private float initialResolutionWidth;
    private float initialResolutionHeight;

    void Start()
    {
        //escala inicial
        initialScale = transform.localScale;

        //resolucao da tela
        initialResolutionWidth = Screen.width;
        initialResolutionHeight = Screen.height;


        Resize();
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Update()
    {
        //checa a resolucao
        if (Screen.width != initialResolutionWidth || Screen.height != initialResolutionHeight)
        {
            Resize();
        }
    }

    private void Resize()
    {
        //tela atual
        float currentResolutionWidth = Screen.width;
        float currentResolutionHeight = Screen.height;

        // calcula escala para largura e altura
        float scaleWidth = currentResolutionWidth / initialResolutionWidth;
        float scaleHeight = currentResolutionHeight / initialResolutionHeight;

        // aplica os fatores
        Vector3 newScale = new Vector3(initialScale.x * scaleWidth, initialScale.y * scaleHeight, initialScale.z);
        transform.localScale = newScale;
    }
}
