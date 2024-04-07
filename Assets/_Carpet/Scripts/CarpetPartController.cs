using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetPartController : KeyHoleController
{
    [SerializeField] private SpriteRenderer partRenderer;

    protected override Renderer GetRenderer()
    {
        return partRenderer;
    }
    
    protected override void SetUpPart(GameObject other)
    {
        other.GetComponent<Bounce>().enabled = false;
        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        other.GetComponent<Rigidbody2D>().freezeRotation = true;
        other.gameObject.transform.localPosition = Vector3.zero;
        other.gameObject.transform.localRotation = Quaternion.Euler(0,0,0);
        Destroy(this.gameObject);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        CheckPosition(other.gameObject);
    }
}
