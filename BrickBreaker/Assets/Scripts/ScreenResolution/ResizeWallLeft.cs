using UnityEngine;

public class ResizeWallLeft : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        UpdatePosition();
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float cameraX = mainCamera.transform.position.x;

        // Ajusta a posição da parede da esquerda para estar na borda da câmera no lado de fora
        float newPositionX = cameraX - cameraHalfWidth - (transform.localScale.x / 2f);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
