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
    [SerializeField] private Collider2D playerCollider;

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
        UpdateLineRenderer(_initialPosition, inputFilter.AngleClamp(position));
    }
    void OnWorldspacePointerUp(Vector2 position){
        lineRenderer.enabled = false;
    }
    
    void UpdateLineRenderer(Vector2 initialPosition, Vector2 angleClamp){
        lines++;

        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("Default", "Tile"));

        var hits = new List<RaycastHit2D>(lines);
        playerCollider.Cast(angleClamp, filter, hits);

        var points = new List<Vector3>();

        Debug.Log(points.Count);

        foreach (var hit in hits)
        {
            points.Add(hit.point);
        }

        Debug.Log(points.Count);

        // points.Add(initialPosition);
        // Vector2 temp = initialPosition;
        // Vector2 angle = angleClamp;

        // for(int n = 1; n < lines; n++){
        //     RaycastHit2D hit = Physics2D.Raycast(temp + angle * .01f, angle, Mathf.Infinity, LayerMask.GetMask("Default") | LayerMask.GetMask("Tile"));

        //     if(!hit)
        //     {
        //         hit = Physics2D.Raycast(temp + angle * .01f, angle);
        //         AddPoint();
        //         break;
        //     }

        //     AddPoint();

        //     void AddPoint()
        //     {
        //         points.Add(hit.point);
        //         angle = Vector2.Reflect(angle.normalized, hit.normal);
        //         temp = points[n];
        //     }
        // }

        // foreach(var item in points){
        //     Debug.LogError(item);
        // }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}
