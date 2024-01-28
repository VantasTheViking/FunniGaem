using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay.Models;
using Unity.Services.Relay;
using Unity.Networking.Transport.Relay;
using Unity.Netcode.Transports.UTP;
public class LobbyDataReciever : MonoBehaviour
{
     public GameObject playerTitle1;
     public GameObject playerTitle2;
     public GameObject playerTitle3;
     public GameObject playerTitle4;
    /*
    private void Awake()
    {
        
        if (LobbyData.isHost)
        {
            NetworkManager.Singleton.StartHost();
        } else
        {
            NetworkManager.Singleton.StartClient();
        }
        
        

        
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
    */
    /*
    async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in" + AuthenticationService.Instance.PlayerId);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();


    }

    async void CreateRelay()
    {
        try
        {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(3);

            string joinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            Debug.Log(joinCode);

            RelayServerData relayServerData = new RelayServerData(allocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartHost();
        }
        catch (RelayServiceException ex)
        {
            Debug.Log(ex);
        }
    }

    async void JoinRelay(string joinCode)
    {
        try
        {
            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode);

            RelayServerData relayServerData = new RelayServerData(joinAllocation, "dtls");

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

            NetworkManager.Singleton.StartClient();
        }
        catch (RelayServiceException e)
        {
            Debug.Log(e);
        }
    }
    */

}
