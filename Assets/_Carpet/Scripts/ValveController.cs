using System;
using System.Collections;
using System.Collections.Generic;
using HurricaneVR.Framework.Components;
using TMPro;
using UnityEngine;

public class ValveController : MonoBehaviour
{
    [SerializeField] private Material _renderer;
    [SerializeField] private bool R;
    [SerializeField] private bool G;
    [SerializeField] private bool B;
    [SerializeField] private HingeJoint _hingeJoint;
    public TextMeshPro Text;

    public HVRRotationTracker Tracker;

    private float oldAngle { get; set; }

    private void Start()
    {
        oldAngle = 0;
    }

    private void Update()
    {
        if (Tracker)
        {
            //print(Remap(Tracker.Angle));
            if(Text)
                Text.text = Remap(Tracker.Angle).ToString();
            //(Math.Abs(oldAngle - _hingeJoint.angle)
            Color color = _renderer.GetColor("_InColor");
            color = new Color(
                R ?
                    color.r >= 0 ?
                        color.r >= 1 ?
                            .99f :
                            color.r + Remap(Tracker.Angle) : //-361 361
                        0.1f :
                    color.r,
                G ?
                    color.g >= 0 ?
                        color.g >= 1 ?
                            .99f :
                            color.g + Remap(Tracker.Angle) :
                        0.1f :
                    color.g,
                B ?
                    color.b >= 0 ? 
                        color.b >= 1 ? 
                            .99f : 
                            color.b + Remap(Tracker.Angle) : 
                        0.1f : 
                    color.b);
            _renderer.SetColor("_InColor", color);
            /*if (Math.Abs(oldAngle - Tracker.Angle) > 2f)
            {
                
                return;
            }*/
        }
        /*if (Math.Abs(oldAngle - Tracker.Angle) < 10f)
        {
            Color color = _renderer.GetColor("_InColor");
            color = new Color(
                R ?
                    color.r >= 0 ?
                        color.r >= 1 ?
                            .9f :
                            color.r + Remap(_hingeJoint.angle) :
                        0.1f :
                    color.r,
                G ?
                    color.g >= 0 ?
                        color.g >= 1 ?
                            .9f :
                            color.g + Remap(_hingeJoint.angle) :
                        0.1f :
                    color.g,
                B ?
                    color.b >= 0 ? 
                        color.b >= 1 ? 
                            .9f : 
                            color.b + Remap(_hingeJoint.angle) : 
                        0.1f : 
                    color.b);
            _renderer.SetColor("_InColor", color);
            return;
        }*/

        oldAngle = Tracker.Angle; //_hingeJoint.angle;
    }
    
    float Remap (float value, float from1 = -361f, float to1 = 361f, float from2 = -1.0f, float to2 = 1.0f) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
