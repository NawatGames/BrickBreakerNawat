using UnityEngine;

public class ResizeWallTop : MonoBehaviour
{
    private Vector3 initialScale;
    private float initialResolutionHeight;

    void Start()
    {
        //escala inicial
        initialScale = transform.localScale;
        initialResolutionHeight = Screen.height;

        Resize();
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Update()
    {
        //checa a resolucao
        if (Screen.height != initialResolutionHeight)
        {
            Resize();
        }
    }

    private void Resize()
    {
        //tela atual
        float currentResolutionHeight = Screen.height;

        // calcula a escala, so precisa da altura
        float scaleHeight = currentResolutionHeight / initialResolutionHeight;

        // aplica os fatores
        Vector3 newScale = new Vector3(initialScale.x, initialScale.y * scaleHeight, initialScale.z);
        transform.localScale = newScale;
    }
}
