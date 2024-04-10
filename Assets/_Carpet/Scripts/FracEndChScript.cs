using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FracEndChScript : KeyHoleController
{
    
    
    [SerializeField] private Animator Anim;
    [SerializeField] private GameObject otherPart;
    [SerializeField] private FracMoveToEnd end;
    protected override void SetUpPart(GameObject other)
    {
        keyMove.SetActive(true);
        Destroy(other.gameObject);
        Destroy(GetRenderer().gameObject);
        
        var animEnabled = otherPart.activeSelf ? end.enabled = true  : end.enabled = false;
        this.enabled = false;
    }
    void Update()
    {
        
    }
}
