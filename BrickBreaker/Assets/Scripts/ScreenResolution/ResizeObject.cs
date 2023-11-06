using UnityEngine;

public class ResizeObject : MonoBehaviour
{
    private Vector3 _initialScale;
    private float _initialResolutionWidth;
    private float _initialResolutionHeight;

    void Start()
    {
        //escala inicial
        _initialScale = transform.localScale;

        //resolucao da tela
        _initialResolutionWidth = Screen.width;
        _initialResolutionHeight = Screen.height;


        Resize();
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Update()
    {
        //checa a resolucao
        if (Screen.width != _initialResolutionWidth || Screen.height != _initialResolutionHeight)
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
        float scaleWidth = currentResolutionWidth / _initialResolutionWidth;
        float scaleHeight = currentResolutionHeight / _initialResolutionHeight;

        // aplica os fatores
        Vector3 newScale = new Vector3(_initialScale.x * scaleWidth, _initialScale.y * scaleHeight, _initialScale.z);
        transform.localScale = newScale;
    }
}
