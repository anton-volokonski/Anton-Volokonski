using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    bool isCoroutineReady = true;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && isCoroutineReady)
        {
            isCoroutineReady = false;
            StartCoroutine(WaitAfterKeyPressed());
        }
    }

    IEnumerator WaitAfterKeyPressed()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        yield return new WaitForSeconds(5);
        isCoroutineReady = true;
    }
}
