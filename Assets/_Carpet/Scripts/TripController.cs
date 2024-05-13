using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripController : MonoBehaviour
{
    [SerializeField] private GameObject ARRoom;

    [SerializeField] private GameObject normalRoom;

    [SerializeField] private Transform teleportPosition;
    
    [SerializeField] private GameObject player;

    public void GoToTrip()
    {
        QuestController.instance.NextStep();
        ARRoom.SetActive(true);
        player.transform.position = teleportPosition.position;
        normalRoom.SetActive(false);
    }
}
