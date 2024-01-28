using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class draw1 : NetworkBehaviour
{
    public Camera Camera;
    public GameObject brush;
    public bool isOnCanvas;
    LineRenderer lineRenderer;
    Vector2 lastPos;
    public Vector2 mouse;
    public Transform canvas;
    GameObject brushInstance;
    public Vector3[] positions;
    private void Start()
    {
        
    }
    private void Update()
    {
        //if (!gameObject.GetComponentInParent<PlayerNetwork>().GetIsOwner()) return;

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
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            SpawnBrushServerRpc();
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

    [ServerRpc(RequireOwnership = false)]
    void SpawnBrushServerRpc()
    {
        brushInstance.GetComponent<NetworkObject>().Spawn(true);
        brushInstance.GetComponent<NetworkObject>().TrySetParent(GetComponentInParent<Transform>());
        //brushInstance.GetComponent<Transform>().SetParent(GetComponentInParent<Transform>());


        positions = new Vector3[lineRenderer.positionCount];
        
        for(int i = 0;  i < positions.Length; i++)
        {
            positions[i] = lineRenderer.GetPosition(i);
        }

        
        brushInstance.GetComponent<DrawColour>().SendPointsServerRpc(positions);
        Debug.Log("Draw");
    }

    void CreateBrush()
    {
        brushInstance = Instantiate(brush, GetComponentInParent<Transform>());
        //brushInstance.GetComponent<NetworkObject>().Spawn(true);
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