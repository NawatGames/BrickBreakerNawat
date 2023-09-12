using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class RawInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private new Camera camera;
    public UnityEvent<Vector2> screenspacePointerUpEvent;
    public UnityEvent<Vector2> screenspacePointerDownEvent;
    public UnityEvent<Vector2> screenspacePointerDragEvent;
    public UnityEvent<Vector2> worldspacePointerUpEvent;
    public UnityEvent<Vector2> worldspacePointerDownEvent;
    public UnityEvent<Vector2> worldspacePointerDragEvent;
    public void OnPointerUp(PointerEventData data){
        screenspacePointerUpEvent.Invoke(data.position);
        worldspacePointerUpEvent.Invoke(camera.ScreenToWorldPoint(data.position));
    }
    public void OnPointerDown(PointerEventData data){
        screenspacePointerDownEvent.Invoke(data.position);
        worldspacePointerDownEvent.Invoke(camera.ScreenToWorldPoint(data.position));
    }
    public void OnDrag(PointerEventData data)
    {
        screenspacePointerDragEvent.Invoke(data.position);
        worldspacePointerDragEvent.Invoke(camera.ScreenToWorldPoint(data.position));
    }  
    void OnEnable(){
        worldspacePointerUpEvent.AddListener(OnWorldspacePointerUp); //se inscrever
    }
    void OnDisable(){
        worldspacePointerUpEvent.RemoveListener(OnWorldspacePointerUp); //se desinscrever
    }
    void OnWorldspacePointerUp(Vector2 position){
        print($"Valor: {position}");
    }
}