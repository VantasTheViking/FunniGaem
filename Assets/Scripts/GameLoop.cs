using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameLoop : MonoBehaviour
{
    public float rounds;
    public float timer = 60;
    public TMP_Text timertext;
    public bool roundstart = true;
    public bool roundend;
    public GameObject VoteUI;
    public float player1vote;
    public float player2vote;
    public float player3vote;
    public float player4vote;
    public Button player1button;
    public Button player2button;
    public Button player3button;
    public Button player4button;
    public bool hasvoted = false;

    // Start is called before the first frame update
    void Start()
    {
        VoteUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        roundstart = true;
        if (timer <=0)
        {
            timer = 0;
        }
        if (roundstart == true)
        {
            timers();
            VoteUI.SetActive(false);

            
            if (timer <= 0)
            {
                roundstart = false;
                roundend = true;
                
            }
        }
        if (roundend)
        {
            vote();
        }
        

    }
    public void vote()
    {
        if (roundend == true)
        {
            VoteUI.SetActive (true);
            
            

        }
        if (hasvoted == true)
        {
            VoteUI.SetActive(false);
            roundstart = true;
            roundend = false;
            timer = 60;
            hasvoted = false;
            
        }

    }
    public void timers()
    {
        timer -= Time.deltaTime;
        timertext.text = timer.ToString("N0");
    }
    public void Roundwin()
    {
        hasvoted = false;
        rounds++;
        roundend = false;
        
        roundstart = true;
    }
    public void player1voted()
    {
        player1vote++;
        hasvoted = true;
        VoteUI.SetActive(false);
        
    }
    public void player2voted()
    {
        player2vote++;
        hasvoted = true;
        VoteUI.SetActive(false);
        
    }
    public void player3voted()
    {
        player3vote++;
        hasvoted = true;
        VoteUI.SetActive(false);
        
    }
    public void player4voted() 
    {
        player4vote++;
        hasvoted = true;
        VoteUI.SetActive(false);
        
    }
    
}
