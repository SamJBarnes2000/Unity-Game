using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawns : MonoBehaviour
{
    public GameObject[] spawnChests;
    public Transform[] spawnLocations1;
    public Transform[] spawnLocations2;
    public Transform[] spawnLocations3;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnChests[0], spawnLocations1[Random.Range(0,spawnLocations1.Length)]);
        Instantiate(spawnChests[0], spawnLocations2[Random.Range(0,spawnLocations2.Length)]);
        Instantiate(spawnChests[0], spawnLocations3[Random.Range(0,spawnLocations3.Length)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
