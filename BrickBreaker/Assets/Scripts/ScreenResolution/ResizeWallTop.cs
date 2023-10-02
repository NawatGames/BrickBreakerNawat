using UnityEngine;

public class ResizeWallTop : MonoBehaviour
{
    private Vector3 initialScale;
    private float initialResolutionHeight;

    void Start()
    {
        // Salva a escala inicial do objeto
        initialScale = transform.localScale;

        // Salva a resolução inicial da tela
        initialResolutionHeight = Screen.height;

        // Chama o método de redimensionamento na inicialização e sempre que a resolução da tela mudar
        Resize();
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Update()
    {
        // Verifica se a resolução da tela mudou
        if (Screen.height != initialResolutionHeight)
        {
            Resize();
        }
    }

    private void Resize()
    {
        // Obtém a resolução da tela atual
        float currentResolutionHeight = Screen.height;

        // Calcula o fator de escala apenas para a altura
        float scaleHeight = currentResolutionHeight / initialResolutionHeight;

        // Aplica o fator de escala à escala inicial do objeto (apenas na direção vertical)
        Vector3 newScale = new Vector3(initialScale.x, initialScale.y * scaleHeight, initialScale.z);
        transform.localScale = newScale;
    }
}
