using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wave3 : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;
    //敵プレハブ白
    public GameObject enemyPrefabW;
    //敵リスト
    public GameObject[] Enemies = new GameObject[12];
    //X座標の最小値
    public float xMinPosition = -10f;
    //X座標の最大値
    public float xMaxPosition = 10f;
    //Y座標の最小値
    public float yMinPosition = 0f;
    //Y座標の最大値
    public float yMaxPosition = 10f;
    //Z座標の最小値
    public float zMinPosition = 10f;
    //Z座標の最大値
    public float zMaxPosition = 20f;
    //撃破カウンターWave1
    private float wave3Count = 0;
    //Enemyのインターバル
    private float EnemyIn = 0.0f;
    //Enemy数
    private float EnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Shuffle(Enemies);
    }

    void Update()
    {
        
    }

    void Shuffle(GameObject[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            GameObject temp = num[i]; // 現在の要素を預けておく
            int randomIndex = Random.Range(0, num.Length); // 入れ替える先をランダムに選ぶ
            num[i] = num[randomIndex]; // 現在の要素に上書き
            num[randomIndex] = temp; // 入れ替え元に預けておいた要素を与える
        }
    }

    public void EnemyInterval()
    {
        EnemyIn += 1.0f * Time.deltaTime;
    }

    //Enemiesの出現
    public void wave3()
    {
        //BOSS
        if (wave3Count >= 0 && EnemyCount == 0)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(enemyPrefabW);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        //Enemies
        if (EnemyIn >= 2.0f && EnemyCount == 1)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[0]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyIn >= 2.0f && EnemyCount == 2)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[1]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyIn >= 2.0f && EnemyCount == 3)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[2]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyIn >= 2.0f && EnemyCount == 4)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[3]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (wave3Count == 1 && EnemyCount == 5)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[4]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (wave3Count == 2 && EnemyCount == 6)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[5]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (wave3Count == 3 && EnemyCount == 7)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[6]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (wave3Count == 4 && EnemyCount == 8)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[7]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (wave3Count == 5 && EnemyCount == 9)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[8]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (wave3Count == 6 && EnemyCount == 10)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[9]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (wave3Count == 7 && EnemyCount == 11)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[10]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (wave3Count == 8 && EnemyCount == 12)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(Enemies[11]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

    }

    public void CountW3()
    {
        wave3Count += 1;
    }

    //ランダムな位置を生成する関数
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition, yMaxPosition);
        float z = Random.Range(zMinPosition, zMaxPosition);

        //Vector3型のPositionを返す
        return new Vector3(x * 60, y, z * 60);
    }

}
