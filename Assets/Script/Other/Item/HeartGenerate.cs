using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGenerate : MonoBehaviour
{
    public GameObject Heart;

    public GameObject[] Heartpos;
    
    int HeartCount = 0;
    int Heartcount = 0;


    // Start is called before the first frame update
    void Start()
    {
        ShuffleHeart(Heartpos);
    }

    void ShuffleHeart(GameObject[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            GameObject temp = num[i]; // Œ»Ý‚Ì—v‘f‚ð—a‚¯‚Ä‚¨‚­
            int randomIndex = Random.Range(0, num.Length); // “ü‚ê‘Ö‚¦‚éæ‚ðƒ‰ƒ“ƒ_ƒ€‚É‘I‚Ô
            num[i] = num[randomIndex]; // Œ»Ý‚Ì—v‘f‚Éã‘‚«
            num[randomIndex] = temp; // “ü‚ê‘Ö‚¦Œ³‚É—a‚¯‚Ä‚¨‚¢‚½—v‘f‚ð—^‚¦‚é
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HeartCount == 1 && Heartcount == 0)
        {
            GameObject heart = Instantiate(Heart);
            heart.transform.position = Heartpos[0].transform.position;

            GameObject heart2 = Instantiate(Heart);
            heart2.transform.position = Heartpos[1].transform.position;

            ++Heartcount;
        }

        if (HeartCount == 43 && Heartcount == 1)
        {
            GameObject heart3 = Instantiate(Heart);
            heart3.transform.position = Heartpos[2].transform.position;

            GameObject heart4 = Instantiate(Heart);
            heart4.transform.position = Heartpos[3].transform.position;

            ++Heartcount;
        }
    }

    public void heart()
    {
        ++HeartCount;
    }
}
