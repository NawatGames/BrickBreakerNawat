using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterLIneRenderer : MonoBehaviour
{
    [SerializeField] private RawInput rawInput;
    private Vector2 _initialPosition;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private InputFilter inputFilter;
    [SerializeField] private GameObject ballShooter;
    [SerializeField] private ShooterRaycast shooterRaycast;
    void OnEnable(){
        rawInput.worldspacePointerDownEvent.AddListener(OnWorldspacePointerDown);
        rawInput.worldspacePointerDragEvent.AddListener(OnWorldspacePointerDrag);
        rawInput.worldspacePointerUpEvent.AddListener(OnWorldspacePointerUp);
    }
    void OnDisable(){
        rawInput.worldspacePointerDownEvent.RemoveListener(OnWorldspacePointerDown);
        rawInput.worldspacePointerDragEvent.RemoveListener(OnWorldspacePointerDrag);
        rawInput.worldspacePointerUpEvent.RemoveListener(OnWorldspacePointerUp);
    }
    void OnWorldspacePointerDown(Vector2 position)
    {
        _initialPosition = ballShooter.transform.position;
    }
    void OnWorldspacePointerDrag(Vector2 position){
        lineRenderer.enabled = true;
        UpdateLineRenderer(_initialPosition, shooterRaycast.GetRaycastHitPosition(inputFilter.AngleClamp(position), _initialPosition));
    }
    void OnWorldspacePointerUp(Vector2 position){
        lineRenderer.enabled = false;
    }
    
    void UpdateLineRenderer(Vector2 initialPosition, Vector2 finalPosition){
        Vector3 []points = new Vector3[2];
        points[0] = initialPosition;
        points[1] = finalPosition;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(points);
    }
}
