using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject CarpetWorld = null;
    [SerializeField] private GameObject carpetPart3;

    public void Teleport()
    {
        Player.transform.position = spawnPosition.position;
    }

    public void Delete()
    {
        Destroy(CarpetWorld);
        carpetPart3.SetActive(true);
    }
}
