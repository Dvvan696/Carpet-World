using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveController : MonoBehaviour
{
    [SerializeField] private Material _renderer;
    [SerializeField] private bool R;
    [SerializeField] private bool G;
    [SerializeField] private bool B;
    [SerializeField] private HingeJoint _hingeJoint;

    private void Update()
    {
        Color color = _renderer.GetColor("_InColor");
        print("OLD " + color);
        color = new Color(R?Remap(_hingeJoint.angle):color.r, G?Remap(_hingeJoint.angle):color.g, B?Remap(_hingeJoint.angle):color.b);
        print("New " + color);
        _renderer.SetColor("_InColor", color);
    }
    
    float Remap (float value, float from1 = -90.0f, float to1 = 90.0f, float from2 = 0.0f, float to2 = 1.0f) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
