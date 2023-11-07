using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowBreakAnimation : MonoBehaviour
{
    [SerializeField] GameObject prefabRainbowAnim;
    void OnDestroy() {
        Instantiate(prefabRainbowAnim, transform.position, transform.rotation);
    }
}
