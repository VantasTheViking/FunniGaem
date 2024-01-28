using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;
public class PlayerNames : NetworkBehaviour
{
    public TMP_Text player1;
    public TMP_Text player2;
    public TMP_Text player3;
    public TMP_Text player4;
    public GameObject networkmanager;
    // Start is called before the first frame update
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetNameServerRpc();
    }
    [ServerRpc]
    public void SetNameServerRpc()
    {
        if (LobbyData.playerNumber == 0)
        {
            //Debug.Log(networkmanager.GetComponent<LobbyProto>().playerName);   
            player1.text = networkmanager.GetComponent<LobbyProto>().playerName;
        }
        if (LobbyData.playerNumber == 1)
        {
            player2.text = networkmanager.GetComponent<LobbyProto>().playerName;
        }
        if (LobbyData.playerNumber == 2)
        {
            player3.text = networkmanager.GetComponent<LobbyProto>().playerName;
        }
        if (LobbyData.playerNumber == 3)
        {
            player4.text = networkmanager.GetComponent<LobbyProto>().playerName;
        }
        SetNameClientRpc();
    }

    [ClientRpc]
    public void SetNameClientRpc()
    {
        if (LobbyData.playerNumber == 0)
        {
            player1.text = networkmanager.GetComponent<LobbyProto>().playerName;
        }
        if (LobbyData.playerNumber == 1)
        {
            player2.text = networkmanager.GetComponent<LobbyProto>().playerName;
        }
        if (LobbyData.playerNumber == 2)
        {
            player3.text = networkmanager.GetComponent<LobbyProto>().playerName;
        }
        if (LobbyData.playerNumber == 3)
        {
            player4.text = networkmanager.GetComponent<LobbyProto>().playerName;
        }
    }
}
