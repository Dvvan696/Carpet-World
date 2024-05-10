using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlocker : MonoBehaviour
{
    [SerializeField] private HingeJoint Door;

    private void Update()
    {
        if (Mathf.Abs(Door.angle) >= 89)
        {
            Door.breakForce = 0.001f;
            Door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Door.GetComponent<Rigidbody>().AddForce(Vector3.right * 50f);
            Destroy(Door.gameObject, 2f);
        }
    }
}
