using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private RawInput rawInput;
    [SerializeField] private InputFilter inputFilter;
    [SerializeField] private LineRendererPointer lineRendererPointer;
}
