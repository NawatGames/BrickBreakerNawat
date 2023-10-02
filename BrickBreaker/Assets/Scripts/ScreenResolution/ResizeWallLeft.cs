using UnityEngine;

public class ResizeWallLeft : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private Vector3 initialPosition;

    void Start()
    {
        // Se a câmera não for definida, usa a câmera principal
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Chama o método de inicialização da posição inicial
        InitializePosition();
    }

    void Update()
    {
        // Verifica se a resolução da tela mudou
        Reposition();
    }

    private void InitializePosition()
    {
        // Obtém a posição inicial em relação à câmera
        initialPosition = mainCamera.WorldToScreenPoint(transform.position);
    }

    private void Reposition()
    {
        // Obtém a posição atual em relação à câmera
        Vector3 currentPosition = mainCamera.WorldToScreenPoint(transform.position);

        // Calcula a diferença de posição na direção X
        float deltaX = initialPosition.x - currentPosition.x;

        // Aplica a diferença na posição da parede (movimento para a esquerda)
        transform.position = mainCamera.ScreenToWorldPoint(new Vector3(currentPosition.x + deltaX, currentPosition.y, currentPosition.z));
    }
}
