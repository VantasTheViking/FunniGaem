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
    float lobbyresetTimerDuration = 20.0f;
    float lobbyTimer = 0;
    float updateListTimerDuration = 1.5f;
    float updateListTimer = 0;
    Lobby joinedLobby;
    string playerName = "John Networking";


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
        if (hostLobby == null)
        {
            try
            {
                string lobbyName = "Lobby";
                int maxPlayers = 4;

                CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
                {
                    Player = new Player
                    {
                        Data = new Dictionary<string, PlayerDataObject> {
                        { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Public, playerName) }
                    }

                    }
                };

                Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);

                hostLobby = lobby;

                Debug.Log($"{lobby.Name}, {lobby.Players.Count}/{lobby.MaxPlayers}");
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e.Message);
            }
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
            joinedLobby = queryResp.Results[0];
            if (queryResp.Results.Count > 0)
            {
                foreach (Lobby l in queryResp.Results)
                {
                    Debug.Log($"Owner Name: {l.Players[0].Data["PlayerName"].Value}, Players: {l.Players.Count}/{l.MaxPlayers}");
                }
            }

        } catch (LobbyServiceException e)
        {
            Debug.Log(e.Message);
        }



    }

    async void DataUpdate()
    {
        if (hostLobby != null)
        {
            lobbyTimer -= Time.deltaTime;
            if (lobbyTimer < 0)
            {
                lobbyTimer = lobbyresetTimerDuration;
                await LobbyService.Instance.SendHeartbeatPingAsync(hostLobby.Id);
            }
        }
        updateListTimer -= Time.deltaTime;
        if (updateListTimer < 0)
        {
            updateListTimer = updateListTimerDuration;
            ListLobbies();
        }
    }
    private void LeaveLobby()
    {
        LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, AuthenticationService.Instance.PlayerId);
    }
    async void JoinLobby()
    {
        await Lobbies.Instance.JoinLobbyByIdAsync(joinedLobby.Id);

    }

    async void MigrateHost()
    {
          try
          {
              hostLobby = await Lobbies.Instance.UpdateLobbyAsync(hostLobby.Id, new UpdateLobbyOptions
              {
                  HostId = joinedLobby.Players[1].Id
              });
              joinedLobby = hostLobby;
          } catch (LobbyServiceException e)
          {
              Debug.Log(e.Message);
          }
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
        DataUpdate(); 
    }

    async void DeleteLobby()
    {
        try
        {
            await LobbyService.Instance.DeleteLobbyAsync(joinedLobby.Id);

        } catch (LobbyServiceException e) {
            Debug.Log(e.Message); 
        }

    }

    private void OnApplicationQuit()
    {
        if (hostLobby != null)
        {
            if (joinedLobby.Players.Count > 0)
            {
                MigrateHost();
                LeaveLobby();
            }
            else
            {
                DeleteLobby();
            }
        } else
        {
            LeaveLobby();
        }
    }
}
