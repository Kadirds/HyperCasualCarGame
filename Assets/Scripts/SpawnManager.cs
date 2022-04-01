using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float nextSpawnTime;
    public GameObject[] carPrefabs;
    [SerializeField] private float spawnDelay = 3;
    

    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }   
    }

    private void Spawn()
    {
        Vector3 spawnPos1 = new Vector3();

        nextSpawnTime = Time.time + spawnDelay;
        int carIndex = Random.Range(0,carPrefabs.Length);
        Instantiate(carPrefabs[carIndex], new Vector3(-72, 1.32f ,190), carPrefabs[carIndex].transform.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
