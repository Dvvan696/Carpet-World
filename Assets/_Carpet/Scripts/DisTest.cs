using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DisTest : MonoBehaviour
{

    [SerializeField] private HingeJoint Door;
    public MeshRenderer Mesh;
    public float dissRate = 0.0125f;
    public float refreshRate = 0.025f;
    private Material MeshesMat;
    
    private void Start()
    {
        MeshesMat = Mesh.material;
    }

    private void Update()
    {
        print(MeshesMat);
        StartCoroutine(DissolveCor());
    }

    IEnumerator DissolveCor()
    {
        
        float counter = 0;
        
        while (MeshesMat.GetFloat("_DissolveAmount") < 1)
        {
            counter += dissRate;
            
            MeshesMat.SetFloat("_DissolveAmount",counter);
            

            yield return new WaitForSeconds(refreshRate);
        }
    }
    
}
