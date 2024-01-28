using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Colour : MonoBehaviour
{
    public LineRenderer linerenderer;
    public GameObject[] colours;
    public int width = 1;

    bool isOwner;

    private void Start()
    {
        linerenderer = GetComponent<LineRenderer>();
        gameObject.GetComponent<draw1>().brush = colours[0];
        
        

    }
    private void Update()
    {
        //if (!gameObject.GetComponentInParent<PlayerNetwork>().GetIsOwner()) return;

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
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            gameObject.GetComponent<draw1>().brush.GetComponent<LineRenderer>().widthMultiplier = 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            gameObject.GetComponent<draw1>().brush.GetComponent<LineRenderer>().widthMultiplier = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            gameObject.GetComponent<draw1>().brush.GetComponent<LineRenderer>().widthMultiplier = 2.0f;
        }
    }
}
