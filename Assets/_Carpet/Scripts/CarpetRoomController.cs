using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetRoomController : MonoBehaviour
{
    [SerializeField] private Material _renderer;

    [SerializeField] private GameObject _spawnObject;

    [SerializeField] private List<ValveController> _valvesList;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color = _renderer.GetColor("_InColor");
        if (color.r <= 0.15f && color.b <= 0.15f && color.g <= 0.15f)
        {
            _spawnObject.SetActive(true);
            QuestController.instance.NextStep();
            foreach (var valve in _valvesList)
            {
                valve.enabled = false;
            }

            this.enabled = false;
        }
    }
}
