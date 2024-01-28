using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class DrawColour : NetworkBehaviour
{
    public LineRenderer lineRenderer;
    public Vector3[] positions;
    public GameObject loop;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        loop = GameObject.FindWithTag("Controller");
        lineRenderer.material = gameObject.GetComponentInParent<LineRenderer>().material;
         if (loop.GetComponent<GameLoop>().timer  == 60)
        {
            Destroy(gameObject);
        }
    }
    [ServerRpc(RequireOwnership = false)]
    public void SendPointsServerRpc(Vector3[] pos)
    {
        positions = pos;

        lineRenderer.positionCount = pos.Length;
        lineRenderer.SetPositions(pos);

        SendPointsClientRpc(pos);
    }

    [ClientRpc] public void SendPointsClientRpc(Vector3[] pos) {
        positions = pos;
        lineRenderer.positionCount = pos.Length;

        lineRenderer.SetPositions(pos);
    }
}
