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
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            keyRenderer.material = visibleMaterial;
            if (Vector3.Distance(other.transform.position, this.transform.position) <= 0.06f)
            {
                keyMove.SetActive(true);
                Destroy(other.gameObject);
                Destroy(keyRenderer.gameObject);
                this.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            keyRenderer.material = invisibleMaterial;
        }
    }
}
