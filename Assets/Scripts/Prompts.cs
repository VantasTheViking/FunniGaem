using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prompts : MonoBehaviour
{
    public int num;
    public float time = 10f;
    public TMP_Text prom;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Prompt();
        prom.text.ToString();
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = 10;
            random();
        }
        
    }
    public void Prompt()
    {
        if (num == 0)
        {
            prom.text = "Clown";

        }

        if (num == 1)
        {
            prom.text = "1";
        }
        if (num == 2)
        {
            prom.text = "2";

        }
        if (num == 3)
        {
            prom.text = "3";

        }
        if (num == 4)
        {
            prom.text = "4";

        }
        if (num == 5)
        {
            prom.text = "5";

        }
        if (num == 6)
        {
            prom.text = "6";

        }
        if (num == 7)
        {
            prom.text = "7";

        }
        if (num == 8)
        {
            prom.text = "8";

        }
        if (num == 9)
        {
            prom.text = "9";

        }
        if (num == 10)
        {
            prom.text = "10";

        }
        

    }
    private void random()
    {

        num = Random.Range(0, 10);

    }
}
