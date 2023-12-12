using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2 : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;
    //敵リスト
    public GameObject[] Enemies = new GameObject[6];
    //撃破カウンターWave1
    private float wave2Count = 0;
    //Enemy数
    private float EnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        ShuffleEnemy(Enemies);
    }

    void Update()
    {

        if (wave2Count == 6)
        {
            EnemySystem.WaveInterval2();
        }
    }

    void ShuffleEnemy(GameObject[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            GameObject temp = num[i]; // 現在の要素を預けておく
            int randomIndex = Random.Range(0, num.Length); // 入れ替える先をランダムに選ぶ
            num[i] = num[randomIndex]; // 現在の要素に上書き
            num[randomIndex] = temp; // 入れ替え元に預けておいた要素を与える
        }
    }

    //Enemiesの出現
    public void wave2()
    {
        if (EnemyCount == 0 && wave2Count == 0)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop xが右端　yが上端
            // leftbottom xが左端　yが下端
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[0]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 1 && wave2Count == 0)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop xが右端　yが上端
            // leftbottom xが左端　yが下端
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[1]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 2 && wave2Count == 1)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop xが右端　yが上端
            // leftbottom xが左端　yが下端
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[2]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 3 && wave2Count == 2)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop xが右端　yが上端
            // leftbottom xが左端　yが下端
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[3]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 4 && wave2Count == 3)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop xが右端　yが上端
            // leftbottom xが左端　yが下端
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[4]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 5 && wave2Count == 4)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop xが右端　yが上端
            // leftbottom xが左端　yが下端
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[5]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }
    }

    public void CountW2()
    {
        wave2Count += 1;
    }
}
