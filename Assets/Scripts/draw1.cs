using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw1 : MonoBehaviour
{
    public Camera Camera;
    public GameObject brush;

    LineRenderer lineRenderer;
    Vector2 lastPos;
    private void Update()
    {
        Drawing();

    }
    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        if (Input.GetKey(KeyCode.Mouse0))
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
    }
    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
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