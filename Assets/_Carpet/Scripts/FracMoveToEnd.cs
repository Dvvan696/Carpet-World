using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracMoveToEnd : MonoBehaviour
{

    [SerializeField] private GameObject Core;
    [SerializeField] private float speed;
    [SerializeField] private TripController _tripController;

    private void OnEnable()
    {
        StartCoroutine(GoHome());
    }

    public void Update()
    {
        Core.transform.position = Vector3.MoveTowards(Core.transform.position,
            new Vector3(0f, 2f, 1f), speed * Time.deltaTime);
        Core.GetComponent<Fractal>().enabled = true;
        Core.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
    
    public IEnumerator GoHome()
    {
        yield return new WaitForSeconds(20f);
        _tripController.GoToHome();
    }
}
