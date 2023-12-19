using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;

    //敵プレハブ赤
    public GameObject enemyPrefabR;
    //敵プレハブ緑
    public GameObject enemyPrefabG;
    //敵プレハブ青
    public GameObject enemyPrefabB;
    //撃破カウンターWave1
    private float wave1Count = 0;

    //Enemy数
    private float EnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCount = 0;
        wave1Count = 0;
    }

    void Update()
    {
        if (EnemyCount == 3 && wave1Count == 3)
        {
            EnemySystem.WaveInterval1();
          
        }
    }

    void ShufflePosX(float[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            float temp = num[i]; // 現在の要素を預けておく
            int randomIndex = Random.Range(0, num.Length); // 入れ替える先をランダムに選ぶ
            num[i] = num[randomIndex]; // 現在の要素に上書き
            num[randomIndex] = temp; // 入れ替え元に預けておいた要素を与える
        }
    }

    void ShufflePosZ(float[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            float temp = num[i]; // 現在の要素を預けておく
            int randomIndex = Random.Range(0, num.Length); // 入れ替える先をランダムに選ぶ
            num[i] = num[randomIndex]; // 現在の要素に上書き
            num[randomIndex] = temp; // 入れ替え元に預けておいた要素を与える
        }
    }

    //Enemiesの出現
    public void wave1()
    {
        if (EnemyCount == 0 && wave1Count == 0)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTop   = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, -1.0f, Camera.main.farClipPlane - 100.0f));

            // rightTop xが右端　yが上端
            // leftbottom xが左端　yが下端
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(enemyPrefabR);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            ++EnemyCount;
        }
    }

    public void CountW1()
    {
        wave1Count += 1;
    }
}
