using UnityEngine;

public class ResizeWallTop : MonoBehaviour
{
    private Vector3 _initialScale;
    private float _initialResolutionHeight;

    void Start()
    {
        //escala inicial
        _initialScale = transform.localScale;
        _initialResolutionHeight = Screen.height;

        Resize();
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Update()
    {
        //checa a resolucao
        if (Screen.height != _initialResolutionHeight)
        {
            Resize();
        }
    }

    private void Resize()
    {
        //tela atual
        float currentResolutionHeight = Screen.height;

        // calcula a escala, so precisa da altura
        float scaleHeight = currentResolutionHeight / _initialResolutionHeight;

        // aplica os fatores
        Vector3 newScale = new Vector3(_initialScale.x, _initialScale.y * scaleHeight, _initialScale.z);
        transform.localScale = newScale;
    }
}
