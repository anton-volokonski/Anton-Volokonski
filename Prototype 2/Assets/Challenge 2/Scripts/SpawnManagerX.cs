using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    //private float spawnInterval = 4.0f;
    
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        coroutine = SpawnRandomBall(3, 6);
        StartCoroutine(coroutine);
    }

    // Spawn random ball at random x position at top of play area
    private IEnumerator SpawnRandomBall (float minInterval, float maxInterval)
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            float result = Random.Range(minInterval, maxInterval);
            // Generate random ball index and random spawn position
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
            int ballIndex = Random.Range(0, ballPrefabs.Length);

            // instantiate ball at random spawn location
            Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
            yield return new WaitForSeconds(result);
        }
    }

}
