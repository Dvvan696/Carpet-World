using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private HingeJoint LeftDoor;
    [SerializeField] private HingeJoint RightDoor;
    [SerializeField] private GameObject TargetObject;

    private void OnTriggerStay(Collider other)
    {
        var sumAngle = LeftDoor.angle + RightDoor.angle * -1;
        if (sumAngle >= 80)
        {
            TargetObject.layer = 0;
            TargetObject.GetComponent<Rigidbody>().isKinematic = false;
            this.enabled = false;
        }
    }
}
