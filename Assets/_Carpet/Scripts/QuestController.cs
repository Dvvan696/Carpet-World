using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QuestController : MonoBehaviour
{
    public static QuestController instance = null; 

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private List<string> questLog = new List<string>();
    [SerializeField] private GameObject info;
    private int _current = 0;

    public void NextStep()
    {
        info.GetComponent<Text>().text = questLog[_current];
        _current++;
    }

}
