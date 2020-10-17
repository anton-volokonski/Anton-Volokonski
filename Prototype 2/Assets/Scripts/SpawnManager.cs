using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float spawnRangeZ = 20;
    private float startDelay = 2;
    private float spawnIntervalFront = 3f;
    private float spawnIntervalSide = 5;
    private float leftRight;
    private float[] spawnPosX = { -20.0f, 20.0f };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnIntervalFront);
        InvokeRepeating("SpawnRandomAnimalLeftRight", startDelay, spawnIntervalSide);
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalLeftRight()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int spawnPosXIndex = Random.Range(0, spawnPosX.Length);

        if (spawnPosX[spawnPosXIndex] < 0)
            leftRight = 90f;
        else
            leftRight = -90f;

        Vector3 spawnPos2 = new Vector3(spawnPosX[spawnPosXIndex], 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        Instantiate(animalPrefabs[animalIndex], spawnPos2, Quaternion.Euler(0f, leftRight, 0f));
    }

}
