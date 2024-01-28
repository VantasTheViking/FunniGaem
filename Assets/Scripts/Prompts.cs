using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;
public class Prompts : NetworkBehaviour
{
    public int num;
    public float time = 10f;
    public TMP_Text prom;

    public string promText;


    public float refreshDuration = 1.0f;
    public float refresh = 0;
    //NetworkVariable<string> promText = new NetworkVariable<string>(" ", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    // Start is called before the first frame update
    private void OnEnable()
    {
        GetComponent<NetworkObject>().Spawn();

    }


    // Update is called once per frame
    void Update()
    {



        if (LobbyData.isHost)
        {
            Debug.Log(LobbyData.playerNumber);
            Prompt();

            promText.ToString();
            time -= Time.deltaTime;
            //if (time < 0)
            //{
            //time = 10;
            //random();


            //}
            if (gameObject.GetComponent<GameLoop>().timer == 60)
            {
                random();
            }

        }

        refresh -= Time.deltaTime;
        if (refresh < 0)
        {
            refresh = refreshDuration;
            //Debug.Log("refresh");
            ChangePromptServerRpc(promText);
            //prom.text = promText;
        }
        
        //
        //ChangePromptClientRpc(promText.ToString());


        //Debug.Log(IsHost);

        //prom.text.ToString();
    }
    [ServerRpc]
    void ChangePromptServerRpc(string s)
    {
        ChangePromptClientRpc(s);
        prom.text = s;

    }
    [ClientRpc]
    void ChangePromptClientRpc(string s)
    {
        prom.text = s;
    }

    public void Prompt()
    {
        if (num == 0)
        {
            promText = "Clown Army";

        }

        if (num == 1)
        {
            promText = "Watermelon gun";
        }
        if (num == 2)
        {
            promText = "Owl in a tank";

        }
        if (num == 3)
        {
            promText = "Galaxy brain";

        }
        if (num == 4)
        {
            promText = "Moose in space";

        }
        if (num == 5)
        {
            promText = "Shark with a Surfboard";

        }
        if (num == 6)
        {
            promText = "Mermaid war crime";

        }
        if (num == 7)
        {
            promText = "Space Pirate ship";

        }
        if (num == 8)
        {
            promText = "Moonwalking koala";

        }
        if (num == 9)
        {
            promText = "T-rex skateboarding ";

        }
        if (num == 10)
        {
            promText = "Balloon train";

        }
        if (num == 11)
        {
            promText = "BIG Peacock";
        }
        if (num == 12)
        {
            promText = "Runaway Ferris Wheel";
        }
        if (num == 13)
        {
            promText = "CatGirl Campfire";
        }
        if (num == 14)
        {
            promText = "Shadowbringers Disco Ball";
        }
        if (num == 15)
        {
            promText = "Hamburger SpaceShip";
        }
        if (num == 16)
        {
            promText = "Toaster Bathtub";
        }
        if (num == 17)
        {
            promText = "Tony Hawk Pro Skater Basketball";
        }
        if (num == 18)
        {
            promText = "Jesus Parrot";
        }
        if (num == 19)
        {
            promText = "John Wick Rainbow";
        }
        if (num == 20)
        {
            promText = "Iceberg Titanic";
        }
        if (num == 21)
        {
            promText = "LOUD Microphone";
        }
        if (num == 22)
        {
            promText = "Holy Spacesuit";
        }
        if (num == 23)
        {
            promText = "tiny Telescope";
        }
        if (num == 24)
        {
            promText = "Baguette Eifel Tower";
        }
        if (num == 25)
        {
            promText = "Thunderbolt and lightning";
        }
        if (num == 26)
        {
            promText = "Rocket Penguin";
        }
        if (num == 27)
        {
            promText = "Tarantula Party";
        }
        if (num == 28)
        {
            promText = "WaterSlide To Hell";
        }
        if (num == 29)
        {
            promText = "Vtuber Pinecone";
        }
        if (num == 30)
        {
            promText = "Tornado Bear";
        }
        if (num == 31)
        {
            promText = "Carousel of Doom";
        }
        if (num == 32)
        {
            promText = "Moonlight Greatsword";
        }
        if (num == 33)
        {
            promText = "Palm Tree Slingshot";
        }
        if (num == 34)
        {
            promText = "Roller Coaster Tycoon";
        }
        if (num == 35)
        {
            promText = "Dinosaur War";
        }
        if (num == 36)
        {
            promText = "Ballon CN Tower";
        }
        if (num == 37)
        {
            promText = "FireFly Grenade";
        }
        if (num == 38)
        {
            promText = "Cup of Tea In the Eyes";
        }
        if (num == 39)
        {
            promText = "Windmill Sword";
        }
        if (num == 40)
        {
            promText = "JellyBean man";
        }
        if (num == 41)
        {
            promText = "Horse ICBM";
        }
        if (num == 42)
        {
            promText = "Satellite Parent";
        }
        if (num == 43)
        {
            promText = "Corporate Cupid";
        }
        if (num == 44)
        {
            promText = "Rabid Cangaroo";
        }
        if (num == 45)
        {
            promText = "Furry Potion";
        }
        if (num == 46)
        {
            promText = "Clown College";
        }
        if (num == 47)
        {
            promText = "Best Girl";
        }
        if (num == 48)
        {
            promText = "Roblox Iceberg";
        }
        if (num == 49)
        {
            promText = "LOOOOONG Carrot";
        }
        if (num == 50)
        {
            promText = "Karma Chamelion";
        }
        if (num == 51)
        {
            promText = "Map of Detroit";
        }
        if (num == 52)
        {
            promText = "Pickle Rick";
        }
        if (num == 53)
        {
            promText = "Spooky Ghost";

        }
        if (num == 54)
        {
            promText = "''Cultured'' Bookshelf";
        }
        if (num == 55)
        {
            promText = "Dragon Deez";
        }
        if (num == 56)
        {
            promText = "Pizza Time";
        }
        if (num == 57)
        {
            promText = "Clown Robot";
        }
        if (num == 58)
        {
            promText = "Samurai Clown";
        }
        if (num == 59)
        {
            promText = "Plastic Nuke";
        }
        if (num == 60)
        {
            promText = "Fate Stay/Night";
        }
        if (num == 61)
        {
            promText = "Pie Tentacle";
        }
        if (num == 62)
        {
            promText = "Exploding Tentacle";
        }
        if (num == 63)
        {
            promText = "Tax Evasion";
        }
        if (num == 64)
        {
            promText = "192.168.01";
        }
        if (num == 65)
        {
            promText = "Crayon Eater";
        }
        if (num == 66)
        {
            promText = "Space Wizard";
        }
        if (num == 67)
        {
            promText = "NPC Character";
        }
        if (num == 68)
        {
            promText = "Blue Man";
        }
        if (num == 69)//nice
        {
            promText = "Dead";
        }
        if (num == 70)
        {
            promText = "Mid Space Game";
        }
        if (num == 71)
        {
            promText = "Japan Simulator";
        }
        if (num == 72)
        {
            promText = "That Game With 2B";
        }
        if (num == 73)
        {
            promText = "Wage Slave Company";
        }
        if (num == 74)
        {
            promText = "Maidenless";
        }
        if (num == 75)
        {
            promText = "Totsugeki!!!!";
        }
        if (num == 76)
        {
            promText = "Nuke California";
        }
        if (num == 77)
        {
            promText = "King Crimson";
        }
        if (num == 78)
        {
            promText = "Family Circle";
        }
    }
    private void random()
    {
        Debug.Log("ran");
        num = Random.Range(0, 78);
        
        

    }
}
