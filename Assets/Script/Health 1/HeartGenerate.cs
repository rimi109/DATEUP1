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
            GameObject temp = num[i]; // 現在の要素を預けておく
            int randomIndex = Random.Range(0, num.Length); // 入れ替える先をランダムに選ぶ
            num[i] = num[randomIndex]; // 現在の要素に上書き
            num[randomIndex] = temp; // 入れ替え元に預けておいた要素を与える
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