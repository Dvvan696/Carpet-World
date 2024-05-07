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
    [SerializeField] protected GameObject keyMove;
   
    
    [SerializeField] private string targetTagName = "Key";
    [SerializeField] private float distanceTrigger = 0.06f;
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
        QuestController.instance.NextStep();
        
    }

    protected void CheckPosition(GameObject other)
    {
        if (other.CompareTag(targetTagName))
        {
            GetRenderer().material = visibleMaterial;
            if (Vector3.Distance(other.transform.position, this.transform.position) <= distanceTrigger)
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
        if (other.CompareTag(targetTagName))
        {
            GetRenderer().material = invisibleMaterial;
        }
    }
}
