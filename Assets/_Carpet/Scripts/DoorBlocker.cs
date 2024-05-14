using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DoorBlocker : MonoBehaviour
{
    [SerializeField] private HingeJoint Door;
    public MeshRenderer Mesh;
    public float dissRate = 0.0125f;
    public float refreshRate = 0.025f;
    private Material[] MeshesMat;

    private void Start()
    {
        MeshesMat = Mesh.materials;
    }

    private void Update()
    {


        if (Door && Mathf.Abs(Door.angle) >= 89)
        {
            Door.breakForce = 0.001f;
            Door.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Door.GetComponent<Rigidbody>().AddForce(Vector3.right * 50f);
            Destroy(Door.gameObject, 10f);
            StartCoroutine(DissolveCor());
        }

    }

    IEnumerator DissolveCor()
    {

        yield return new WaitForSeconds(3f);



        float counter = 0;
        while (MeshesMat[0].GetFloat("_DissolveAmount") < 1)
        {
            counter += dissRate;

            MeshesMat[0].SetFloat("_DissolveAmount", counter);


            yield return new WaitForSeconds(refreshRate);
        }
    }
}

    

