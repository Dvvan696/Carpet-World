using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMoveController : MonoBehaviour
{
    [SerializeField] private HingeJoint Key;
    [SerializeField] private HingeJoint LeftDoor;
    [SerializeField] private HingeJoint RightDoor;

    private void OnTriggerStay(Collider other)
    {
        if (Key.angle >= 80)
        {
            LeftDoor.GetComponent<Rigidbody>().isKinematic = false;
            RightDoor.GetComponent<Rigidbody>().isKinematic = false;
            JointLimits a = new JointLimits();
            a.max = 90;
            LeftDoor.limits = a;
            a.max = 0;
            a.min = -90;
            RightDoor.limits = a;
            Key.GetComponent<BoxCollider>().enabled = false;
            this.enabled = false;

            LeftDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            LeftDoor.GetComponent<Rigidbody>().freezeRotation = false;
            LeftDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        
            RightDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            RightDoor.GetComponent<Rigidbody>().freezeRotation = false;
            RightDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}
