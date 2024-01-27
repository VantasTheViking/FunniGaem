using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawColour : MonoBehaviour
{
    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.material = gameObject.GetComponentInParent<LineRenderer>().material;
    }
}
