using UnityEngine;

public class ResizeWallLeft : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private Vector3 _initialPosition;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        //posicao
        InitializePosition();
    }

    void Update()
    {
        //checa a resolucao
        Reposition();
    }

    private void InitializePosition()
    {
        //posicao inicial
        _initialPosition = mainCamera.WorldToScreenPoint(transform.position);
    }

    private void Reposition()
    {
        //posicao atual
        Vector3 currentPosition = mainCamera.WorldToScreenPoint(transform.position);

        //diferenca de posicao no X
        float deltaX = _initialPosition.x - currentPosition.x;

        // Aplica a posicao da parede
        transform.position = mainCamera.ScreenToWorldPoint(new Vector3(currentPosition.x + deltaX, currentPosition.y, currentPosition.z));
    }
}
