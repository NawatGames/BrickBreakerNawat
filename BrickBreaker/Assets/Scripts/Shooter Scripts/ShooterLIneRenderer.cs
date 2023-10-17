using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterLIneRenderer : MonoBehaviour
{
    public int lines = 1;
    [SerializeField] private RawInput rawInput;
    private Vector2 _initialPosition;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private InputFilter inputFilter;
    [SerializeField] private GameObject ballShooter;

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
    void OnWorldspacePointerDown(Vector2 position){
        _initialPosition = ballShooter.transform.position;
    }
    void OnWorldspacePointerDrag(Vector2 position){
        lineRenderer.enabled = true;
        UpdateLineRenderer(lines, _initialPosition, inputFilter.AngleClamp(position));
    }
    void OnWorldspacePointerUp(Vector2 position){
        lineRenderer.enabled = false;
    }
    
    void UpdateLineRenderer(int lines, Vector2 initialPosition, Vector2 angleClamp){
        lines++;
        List<Vector3> points = new List<Vector3>();

        points.Add(initialPosition);
        Vector2 temp = initialPosition;
        Vector2 angle = angleClamp;

        for(int n = 1; n < lines; n++){
            RaycastHit2D hit = Physics2D.Raycast(temp + angle * .01f, angle, Mathf.Infinity, LayerMask.GetMask("Default") | LayerMask.GetMask("Tile"));

            if(!hit)
            {
                hit = Physics2D.Raycast(temp + angle * .01f, angle);
                AddPoint();
                break;
            }

            AddPoint();

            void AddPoint()
            {
                points.Add(hit.point);
                angle = Vector2.Reflect(angle.normalized, hit.normal);
                temp = points[n];
            }
        }

        // foreach(var item in points){
        //     Debug.LogError(item);
        // }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}
