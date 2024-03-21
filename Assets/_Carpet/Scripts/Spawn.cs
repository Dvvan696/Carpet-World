using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject Player;

    public void Teleport()
    {
        Player.transform.position = spawnPosition.position;
    }
}
