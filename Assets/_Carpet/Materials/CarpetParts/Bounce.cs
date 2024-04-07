using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    

    void StartBounce()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            _rb2d.AddForce(new Vector2(0.0000002f,-0.00000015f));
        }
        else
        {
            _rb2d.AddForce(new Vector2(-0.0000002f,-0.00000015f));
        }
    }
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        Invoke("StartBounce",2);
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb2d.velocity.x == 0)
        {
            _rb2d.velocity = new Vector2(Random.Range(0.5f, 1.5f), _rb2d.velocity.y);
        }
        else if (_rb2d.velocity.y == 0)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, Random.Range(0.5f, 1.5f));
        }
    }

    
}
