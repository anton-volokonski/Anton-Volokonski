using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpTest : MonoBehaviour
{
    // public GameObject[] cubes;

    //public GameObject player;

    // [SerializeField]
    // private string hi = "Hi!";
    //public int[] someDigits = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(someDigits[3]);
        GetComponent<Renderer>().material.color = Color.red;
        StartCoroutine(Test());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Test()
    {
        yield return "hello";
    }

}
