using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 20.0f;
    float turnSpeed = 50.0f;
    float inputVertical1;
    float inputHorizontal1;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.Translate(0, 0, 1);

        inputVertical1 = Input.GetAxis("Vertical1");
        inputHorizontal1 = Input.GetAxis("Horizontal1");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * inputVertical1);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * inputHorizontal1);

        // Debug.Log();


    }
}
