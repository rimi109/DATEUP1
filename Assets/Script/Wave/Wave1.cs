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
    private float wave1Count = 0;
    //Enemy数
    private float EnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        if (EnemyCount == 3 && wave1Count == 3)
        {
            EnemySystem.WaveInterval1();
        }
    }

    //Enemiesの出現
    public void wave1()
    {
        if (EnemyCount == 0 && wave1Count == 0)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(enemyPrefabR);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyCount == 1 && wave1Count == 1)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(enemyPrefabG);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyCount == 2 && wave1Count == 2)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject enemy = Instantiate(enemyPrefabB);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }
    }

    public void CountW1()
    {
        wave1Count += 1;
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
