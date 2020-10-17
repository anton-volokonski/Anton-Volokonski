using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    float speed = 20.0f;
    float turnSpeed = 50.0f;
    float inputVertical2;
    float inputHorizontal2;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.Translate(0, 0, 1);

        inputVertical2 = Input.GetAxis("Vertical2");
        inputHorizontal2 = Input.GetAxis("Horizontal2");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * inputVertical2);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * inputHorizontal2);

        // Debug.Log();


    }
}
