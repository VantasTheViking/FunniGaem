using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class LobbyDataReciever : MonoBehaviour
{
    [SerializeField] public GameObject playerTitle1;
    [SerializeField] public GameObject playerTitle2;
    [SerializeField] public GameObject playerTitle3;
    [SerializeField] public GameObject playerTitle4;

    private void Awake()
    {
        /*
        if (LobbyData.isHost)
        {
            NetworkManager.Singleton.StartHost();
        } else
        {
            NetworkManager.Singleton.StartClient();
        }
        */
        

        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            NetworkManager.Singleton.StartHost();
            Debug.Log("StartHost");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            NetworkManager.Singleton.StartClient();
            Debug.Log("StartCLient");
        }
    }
    private void Start()
    {
        
    }
}
