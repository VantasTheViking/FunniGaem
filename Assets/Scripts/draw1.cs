using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw1 : MonoBehaviour
{
    public Camera Camera;
    public GameObject brush;
    public bool isOnCanvas;
    LineRenderer lineRenderer;
    Vector2 lastPos;
    public Vector2 mouse;
    public Transform canvas;
    private void Start()
    {
        
    }
    private void Update()
    {
        Drawing();
        mouse = Camera.ScreenToWorldPoint(Input.mousePosition);
    }
    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) )
        {
            CreateBrush();
        }
        if (Input.GetKey(KeyCode.Mouse0) )
        {
            Vector2 mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos != lastPos)
            {
                AddAPoint(mousePos);
                lastPos = mousePos;
            }

        }
        else
        {
            lineRenderer = null;
            
        }
        //if (Input.GetKeyUp(KeyCode.Mouse0))
        //{
            //Colour[] l =  gameObject.GetComponentsInChildren<Colour>();  
            //foreach (Colour col in l)
            //{
                //col.enabled = false;
            //}
            
        //}
    }
    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush, GetComponentInParent<Transform>());
        lineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);

        lineRenderer.SetPosition(0, mousePos);
        lineRenderer.SetPosition(1, mousePos);

    }
    private void AddAPoint(Vector2 pointPos)
    {
        lineRenderer.positionCount++;
        int positionIndex = lineRenderer.positionCount - 1;
        lineRenderer.SetPosition(positionIndex, pointPos);
    }
    

}