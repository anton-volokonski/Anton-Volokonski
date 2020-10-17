using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 20.0f;
    float turnSpeed = 50.0f;
    float inputVertical;
    float inputHorizontal;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.Translate(0, 0, 1);

        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * inputVertical);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * inputHorizontal);

        // Debug.Log();


    }
}
