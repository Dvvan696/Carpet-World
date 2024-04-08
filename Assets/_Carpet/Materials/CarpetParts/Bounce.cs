using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bounce : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private bool up;
    

    void StartBounce()
    {
        //int rand = Random.Range(0, 10);
        if (up)
        {
            _rb.AddForce(new Vector3(0.0000002f,0.00000015f,0));
        }
        else
        {
            _rb.AddForce(new Vector3(-0.0000002f,-0.00000015f,0));
        }
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Invoke("StartBounce",2);
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.velocity.x <= 0.025f && _rb.velocity.x >= -0.025f)
        {
            _rb.velocity = new Vector3(Random.Range(0.5f, 1.5f), _rb.velocity.y,0);
        }
        else if (_rb.velocity.y <= 0.025f && _rb.velocity.y >= -0.025f)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, Random.Range(0.5f, 1.5f),0);
        }
    }

    
}
