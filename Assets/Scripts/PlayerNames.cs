using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNames : MonoBehaviour
{
    public TMP_Text player1;
    public TMP_Text player2;
    public TMP_Text player3;
    public TMP_Text player4;
    public GameObject networkmanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player1.text = networkmanager.GetComponent<LobbyDataReciever>().playerTitle1.ToString();
        player2.text = networkmanager.GetComponent<LobbyDataReciever>().playerTitle2.ToString();
        player3.text = networkmanager.GetComponent<LobbyDataReciever>().playerTitle3.ToString();
        player4.text = networkmanager.GetComponent<LobbyDataReciever>().playerTitle4.ToString();
    }
}
