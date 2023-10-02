using UnityEngine;

public class ResizeObject : MonoBehaviour
{
    private Vector3 initialScale;
    private float initialResolutionWidth;
    private float initialResolutionHeight;

    void Start()
    {
        // Salva a escala inicial do objeto
        initialScale = transform.localScale;

        // Salva a resolução inicial da tela
        initialResolutionWidth = Screen.width;
        initialResolutionHeight = Screen.height;

        // Chama o método de redimensionamento na inicialização e sempre que a resolução da tela mudar
        Resize();
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Update()
    {
        // Verifica se a resolução da tela mudou
        if (Screen.width != initialResolutionWidth || Screen.height != initialResolutionHeight)
        {
            Resize();
        }
    }

    private void Resize()
    {
        // Obtém a resolução da tela atual
        float currentResolutionWidth = Screen.width;
        float currentResolutionHeight = Screen.height;

        // Calcula os fatores de escala para largura e altura
        float scaleWidth = currentResolutionWidth / initialResolutionWidth;
        float scaleHeight = currentResolutionHeight / initialResolutionHeight;

        // Aplica os fatores de escala à escala inicial do objeto
        Vector3 newScale = new Vector3(initialScale.x * scaleWidth, initialScale.y * scaleHeight, initialScale.z);
        transform.localScale = newScale;
    }
}
