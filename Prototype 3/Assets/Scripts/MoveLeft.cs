using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    public float superAccelerator = 2;
    private float speedBuffer;
    private bool isPassed = false;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        speedBuffer = playerControllerScript.playerAnim.speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerControllerScript.transform.position.x >= 0)
        {
            MoveAndSuperSpeed();
        }
        
        if (Input.GetKey(KeyCode.S) && gameObject.CompareTag("Obstacle") && transform.position.x < -1 && isPassed == false)
        {
            playerControllerScript.score += 2;
            Debug.Log("This is turbo! Your score:" + playerControllerScript.score + " | Max scores: " + playerControllerScript.maxScore);
            isPassed = true;
        }
        else if (gameObject.CompareTag("Obstacle") && transform.position.x < -1 && isPassed == false)
        {
            playerControllerScript.score++;
            Debug.Log("Your score:" + playerControllerScript.score + " | Max scores: " + playerControllerScript.maxScore);
            isPassed = true;
        }

        if (gameObject.CompareTag("Obstacle") && transform.position.x < leftBound)
        {
            Destroy(gameObject);
            isPassed = false;
        }
    }
    void MoveAndSuperSpeed()
    {
        if (!playerControllerScript.gameOver)
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed * superAccelerator);
                playerControllerScript.playerAnim.speed = superAccelerator;
            }
            else
            {
                playerControllerScript.playerAnim.speed = speedBuffer;
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
    }
}
