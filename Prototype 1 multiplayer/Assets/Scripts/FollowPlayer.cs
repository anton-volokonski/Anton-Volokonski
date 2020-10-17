using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // GameObject player;

    public GameObject player;
    private Vector3 cameraOutsideView = new Vector3(0, 4.3f, -6.7f);
    private Vector3 cameraInsideView = new Vector3(0, 1.9f, 1.2f);
    private Vector3 cameraState;

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.Find("Vehicle");
        cameraState = cameraOutsideView;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + cameraState;

        if (Input.GetKeyDown(KeyCode.C) && cameraState != cameraInsideView)
        {
            cameraState = cameraInsideView;

        }
        else if (Input.GetKeyDown(KeyCode.C) && cameraState == cameraInsideView)
        {
            cameraState = cameraOutsideView;
        }
        
    }
}
