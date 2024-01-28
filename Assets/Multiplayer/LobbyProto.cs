using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using TMPro;
using Unity.Services.Relay.Models;
using Unity.Services.Relay;


public class LobbyProto : MonoBehaviour 
{
    Lobby hostLobby;
    float lobbyresetTimerDuration = 20.0f;
    float lobbyTimer = 0;
    float updateListTimerDuration = 3.0f;
    float updateListTimer = 0;
    Lobby joinedLobby;
    public string playerName = "John Networking";
    int maxPlayers = 2;
    bool running = true;
    float pollTimerDuration = 1.5f;
    float pollTimer = 0;

    [SerializeField] TMP_Text debugText;
    [SerializeField] GameObject start;
    [SerializeField] GameObject game;
    [SerializeField] TMP_Text server1Text;
    [SerializeField] TMP_Text server2Text;
    [SerializeField] TMP_Text server3Text;
    [SerializeField] TMP_Text server4Text;


    public void ReadName(string name)
    {
        playerName = name;
    }

    // Start is called before the first frame update
    async void Start()
    {
        //Debug.Log(OwnerClientId);

        

        

    }

    public async void CreateLobby()
    {
        if (hostLobby == null)
        {
            try
            {
                string lobbyName = "Lobby";
                

                CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
                {
                    Player = new Player
                    {
                        Data = new Dictionary<string, PlayerDataObject>
                        {
                            { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Public, playerName)},
                            //
                                
                            
                        }
                    

                    },
                    Data = new Dictionary<string, DataObject> {

                        { "GameKey", new DataObject(DataObject.VisibilityOptions.Member, "0")}
                    }
                };

                Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);

                hostLobby = lobby;

                Debug.Log($"owner id: {hostLobby.Players[0].Id}");
                //Debug.Log($"{lobby.Name}, {lobby.Players.Count}/{lobby.MaxPlayers}");
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
            //
            //Debug.Log($"Lobbies {queryResp.Results.Count}");

            //Delete This After Testing
            //joinedLobby = queryResp.Results[0];

            /*
            if (queryResp.Results.Count > 0)
            {
                foreach (Lobby l in queryResp.Results)
                {

                    Debug.Log($"Owner Name: {l.Players[0].Data["PlayerName"].Value}, Players: {l.Players.Count}/{l.MaxPlayers}");
                }
            }
            */

            server1Text.text = $"Owner Name: {queryResp.Results[0].Players[0].Data["PlayerName"].Value}, Size: {queryResp.Results[0].Players.Count}/{queryResp.Results[0].MaxPlayers}";
            server2Text.text = $"Owner Name: {queryResp.Results[1].Players[1].Data["PlayerName"].Value}, Size: {queryResp.Results[1].Players.Count}/{queryResp.Results[1].MaxPlayers}";
            server3Text.text = $"Owner Name: {queryResp.Results[2].Players[2].Data["PlayerName"].Value}, Size: {queryResp.Results[2].Players.Count}/{queryResp.Results[2].MaxPlayers}";
            server4Text.text = $"Owner Name: {queryResp.Results[3].Players[3].Data["PlayerName"].Value}, Size: {queryResp.Results[3].Players.Count}/{queryResp.Results[3].MaxPlayers}";


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
    public async void JoinLobby(int x)
    {
        QueryResponse queryResp = await Lobbies.Instance.QueryLobbiesAsync();

        //joinedLobby = queryResp.Results[0];
        if (queryResp.Results[x] != null)
        {
            Debug.Log("Valid");
            joinedLobby = queryResp.Results[x];
            
            LobbyData.playerNumber = joinedLobby.Players.Count;

            await Lobbies.Instance.JoinLobbyByIdAsync(joinedLobby.Id);
        }
        

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
        /*
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
            JoinLobby(0);
        }
        */
        if (running)
        {
            DataUpdate();
            PollUpdates();
        }
    }

    public async void PollUpdates()
    {
        pollTimer -= Time.deltaTime;
        if (pollTimer < 0)
        {
            pollTimer = pollTimerDuration;

            if (joinedLobby != null)
            {
                Debug.Log("Updated JoinLobby");
                Lobby lobby = await LobbyService.Instance.GetLobbyAsync(joinedLobby.Id);
                joinedLobby = lobby;
            }
            if (hostLobby != null)
            {
                Debug.Log("updated host lobby");
                Lobby lobby = await LobbyService.Instance.GetLobbyAsync(hostLobby.Id);
                hostLobby = lobby;
            }

            //Debug.Log($"joinedlobby players: {joinedLobby.Players.Count}");
            //Debug.Log($"hostlobby players: {hostLobby.Players.Count}");

            
            Debug.Log( $"JoinedLobbyGameKeyVal:{joinedLobby.Data["GameKey"].Value}");
            //joinedLobby = LobbyService.Instance.GetLobbyAsync(joinedLobby.Id).Result;
            //Debug.Log(joinedLobby.Players.Count);
            if (joinedLobby.Data["GameKey"].Value != "0")
            {
                Debug.Log("Start");
                LobbyData.isHost = false;
                running = false;


                GameRelay.Instance.JoinRelay(joinedLobby.Data["GameKey"].Value);

                start.SetActive(false);
                game.SetActive(true);
                //SceneManager.LoadScene("Canvas");
            }
            


            /*
            if (hostLobby != null)
            {
                Debug.Log(hostLobby.Data["GameKey"].Value);
                Debug.Log(hostLobby.Players.Count);
                if (hostLobby.Players.Count == maxPlayers)
                {
                    
                }
            }*/
        }

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

    

    async void StartGame()
    {

        try
        {
            //debugText.text = "startgame";
            string relayCode = await GameRelay.Instance.CreateRelay();
            debugText.text = relayCode;

            Lobby lobby = await Lobbies.Instance.UpdateLobbyAsync(hostLobby.Id, new UpdateLobbyOptions
            {
                Data = new Dictionary<string, DataObject>
                {
                    { "GameKey", new DataObject(DataObject.VisibilityOptions.Member, relayCode)}

                }
            
            });
            debugText.text = "gameStart";

            NetworkManager.Singleton.StartHost();
            
            start.SetActive(false);
            game.SetActive(true);
        } catch (LobbyServiceException e)
        {
            debugText.text = e.Message;
        }
    }

    public void buttonStart()
    {
        debugText.text = "buttonPress";

        LobbyData.isHost = true;
        running = false;

        StartGame();
        //SceneManager.LoadScene("Canvas");
    }
    private void OnApplicationQuit()
    {
        if (hostLobby != null)
        {
            if (hostLobby.Players.Count > 0)
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
