using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;

    public float speed = 10.0f;
    public float xRange = 10;
    public float zRangeUp = 5;
    public float zRangeDown = 2;
    public GameObject projectilePrefab;

    public static int playerLives = 3;
    public static int playerScore = 0;

    void Update()
    {
        //player limits left right move
        if (transform.position.x < -xRange) 
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        // player limits up down move
        if (transform.position.z < -zRangeDown)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRangeDown);
        if (transform.position.z > zRangeUp)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeUp);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);


        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            var pizzaPoz = transform.position + new Vector3 (0, 0, 1);
            Instantiate(projectilePrefab, pizzaPoz, projectilePrefab.transform.rotation);
        }
        
        if (playerLives == 0)
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
    }

}
