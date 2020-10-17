using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && PlayerController.playerLives > 0)
        {
            PlayerController.playerLives--;
            Debug.Log("Lives: " + PlayerController.playerLives + " Score: " + PlayerController.playerScore);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Food"))
        {
            gameObject.GetComponent<AnimalHunger>().FeedAnimal(1);
            Destroy(other.gameObject);
            PlayerController.playerScore++;
            Debug.Log("Lives: " + PlayerController.playerLives + " Score: " + PlayerController.playerScore);
        }

        if (other.gameObject.CompareTag("Border") && PlayerController.playerLives != 0)
        {
            PlayerController.playerLives--;
            Debug.Log("Lives: " + PlayerController.playerLives + " Score: " + PlayerController.playerScore);
            Destroy(gameObject);
        }

    }
}
