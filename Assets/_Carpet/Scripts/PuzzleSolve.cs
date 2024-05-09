using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolve : MonoBehaviour
{
    private Animator _animator;
    private bool isSolved = false;
    
    void Start () {
        _animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (!isSolved)
        {
            StartCoroutine(Solve());
        }
    }

    private IEnumerator Solve()
    {
        print(transform.childCount);
            if (transform.childCount == 8)
            {

                _animator.SetBool("Solved", true);
                yield return new WaitForSeconds(1.5f);
                _animator.enabled = false;
                isSolved = true;
            }

    }
}


