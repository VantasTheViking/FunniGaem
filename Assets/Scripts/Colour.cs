using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour : MonoBehaviour
{
    public LineRenderer linerenderer;
    public GameObject[] colours;


    private void Start()
    {
        linerenderer = GetComponent<LineRenderer>();
        gameObject.GetComponent<draw1>().brush = colours[0];
        

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameObject.GetComponent<draw1>().brush = colours[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameObject.GetComponent<draw1>().brush = colours[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gameObject.GetComponent<draw1>().brush = colours[2];

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gameObject.GetComponent<draw1>().brush = colours[3];

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            gameObject.GetComponent<draw1>().brush = colours[4];

        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            gameObject.GetComponent<draw1>().brush = colours[5];

        }

    }
}
