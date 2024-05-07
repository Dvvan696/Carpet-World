using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetPartController : KeyHoleController
{
    [SerializeField] private SpriteRenderer partRenderer;
    [SerializeField] private int layer = 12;
    [SerializeField] private Sprite carpetSprite;
    [SerializeField] private Material standardMaterial;

    protected override Renderer GetRenderer()
    {
        return partRenderer;
    }
    
    protected override void SetUpPart(GameObject other)
    {
        partRenderer.sprite = carpetSprite;
        partRenderer.material = standardMaterial;
        var partRendererColor = partRenderer.color;
        partRendererColor.a = 1;
        partRenderer.color = partRendererColor;
        /*other.GetComponent<Bounce>().enabled = false;
        other.GetComponent<Rigidbody>().velocity = Vector2.zero;
        other.GetComponent<Rigidbody>().freezeRotation = true;
        other.gameObject.transform.localPosition = Vector3.zero;
        other.gameObject.transform.localRotation = Quaternion.Euler(0,0,0);
        other.layer = layer;
        other.GetComponent<Rigidbody>().isKinematic = true;*/
        Destroy(other.gameObject);
        this.enabled = false;
    }
}
