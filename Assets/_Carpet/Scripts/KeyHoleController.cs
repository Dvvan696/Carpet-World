using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyHoleController : MonoBehaviour
{
    [SerializeField] private MeshRenderer keyRenderer;
    [SerializeField] private Material visibleMaterial;
    [SerializeField] private Material invisibleMaterial;
    [SerializeField] private GameObject keyMove;

    [SerializeField] private string targetTagKey = "Key";
    
    protected virtual Renderer GetRenderer()
    {
        return keyRenderer;
    }

    protected virtual void SetUpPart(GameObject other)
    {
        keyMove.SetActive(true);
        Destroy(other.gameObject);
        Destroy(GetRenderer().gameObject);
        this.enabled = false;
    }

    protected void CheckPosition(GameObject other)
    {
        if (other.CompareTag(targetTagKey))
        {
            GetRenderer().material = visibleMaterial;
            if (Vector3.Distance(other.transform.position, this.transform.position) <= 0.06f)
            {
                SetUpPart(other);
            }
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        CheckPosition(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTagKey))
        {
            GetRenderer().material = invisibleMaterial;
        }
    }
}
