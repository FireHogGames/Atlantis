using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;

    [SerializeField] private Transform[] spawnPoints;
    private void Start()
    {
        int i = 0;
        i = Random.Range(0, spawnPoints.Length);

        Instantiate(spawnObject, spawnPoints[i].position, Quaternion.identity);
    }
}
