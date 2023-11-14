using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAnimation : MonoBehaviour
{
    [SerializeField] private FireBall _fireBall;
    [SerializeField] GameObject prefabFireAnim;

    private void OnEnable(){
        _fireBall.FireBallCollisionEvent.AddListener(OnFireBallHit);
    }

    private void OnDisable(){
        _fireBall.FireBallCollisionEvent.RemoveListener(OnFireBallHit);
    }
    
    private void OnFireBallHit(GameObject tile)
    {
        if (tile.GetComponent<TileHealth>() != null)
        {
            Instantiate(prefabFireAnim, transform.position, transform.rotation);    
        }
    }
}
