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
            GameObject temp = num[i]; // ���݂̗v�f��a���Ă���
            int randomIndex = Random.Range(0, num.Length); // ����ւ����������_���ɑI��
            num[i] = num[randomIndex]; // ���݂̗v�f�ɏ㏑��
            num[randomIndex] = temp; // ����ւ����ɗa���Ă������v�f��^����
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
