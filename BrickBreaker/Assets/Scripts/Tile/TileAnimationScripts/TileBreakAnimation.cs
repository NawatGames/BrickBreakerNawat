using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBreakAnimation : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    void OnDestroy() {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
