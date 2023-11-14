using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBreakAnimation : MonoBehaviour
{
    // Start is called before the first frame update
        [SerializeField] GameObject prefab;

    private void OnDestroy()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}