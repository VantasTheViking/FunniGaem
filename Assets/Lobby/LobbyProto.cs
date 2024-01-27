using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;

public class LobbyProto : MonoBehaviour 
{
    Lobby hostLobby;
    float resetTimer = 120.0f;
    float timer = 0;
    Lobby testLob;
    

    // Start is called before the first frame update
    async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

    }

    async void CreateLobby()
    {
        try {
            string lobbyName = "Lobby";
            int maxPlayers = 4;

            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers);

            hostLobby = lobby;

            Debug.Log($"{lobby.Name}, {lobby.Players.Count}/{lobby.MaxPlayers}");
        } catch (LobbyServiceException e)
        {
            Debug.Log(e.Message);
        }
        

    }

    async void ListLobbies()
    {
        try
        {
            QueryLobbiesOptions queryLobbiesOptions = new QueryLobbiesOptions
            {
                Count = 10,

                Filters = new List<QueryFilter>
                {
                    new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT)
                },

                Order = new List<QueryOrder>
                {
                    new QueryOrder(false, QueryOrder.FieldOptions.Created)
                }

            };

            QueryResponse queryResp = await Lobbies.Instance.QueryLobbiesAsync();
            Debug.Log($"Lobbies {queryResp.Results.Count}");
            testLob = queryResp.Results[0];
            foreach (Lobby l in queryResp.Results)
            {
                Debug.Log($"Server Name: {l.Name}, Players: {l.Players.Count}/{l.MaxPlayers}");
            }

        } catch (LobbyServiceException e)
        {
            Debug.Log(e.Message);
        }



    }

    async void LobbyReActivate()
    {
        if (hostLobby != null)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = resetTimer;
                await LobbyService.Instance.SendHeartbeatPingAsync(hostLobby.Id);
            }
        }
    }

     async void JoinLobby()
    {
        await Lobbies.Instance.JoinLobbyByIdAsync(testLob.Id);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CreateLobby();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            ListLobbies();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            JoinLobby();
        }
        LobbyReActivate(); 
    }
}
