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

    public static string promText;

    //NetworkVariable<string> promText = new NetworkVariable<string>(" ", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsHost)
        {

            Prompt();
            promText.ToString();

            time -= Time.deltaTime;
            if (time < 0)
            {
                time = 10;
                random();
                
            }

            ChangePromptClientRpc(promText.ToString());
        }

        //Debug.Log(IsHost);
        
        //prom.text.ToString();
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
            promText = "Clown";

        }

        if (num == 1)
        {
            promText = "1";
        }
        if (num == 2)
        {
            promText = "2";

        }
        if (num == 3)
        {
            promText = "3";

        }
        if (num == 4)
        {
            promText = "4";

        }
        if (num == 5)
        {
            promText = "5";

        }
        if (num == 6)
        {
            promText = "6";

        }
        if (num == 7)
        {
            promText = "7";

        }
        if (num == 8)
        {
            promText = "8";

        }
        if (num == 9)
        {
            promText = "9";

        }
        if (num == 10)
        {
            promText = "10";

        }
        

    }
    private void random()
    {

        num = Random.Range(0, 10);

    }
}
