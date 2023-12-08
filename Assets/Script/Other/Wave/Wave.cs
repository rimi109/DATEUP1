using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wave : MonoBehaviour
{

    //敵プレハブ
    public GameObject[] enemyPrefab;
    //敵ランダム
    private int number;
    //時間間隔の最小値
    public float minTime = 0.5f;
    //時間間隔の最大値
    public float maxTime = 1f;
    //X座標の最小値
    public float xMinPosition = -1f;
    //X座標の最大値
    public float xMaxPosition = 1f;
    //Y座標の最小値
    public float yMinPosition = 3f;
    //Y座標の最大値
    public float yMaxPosition = 3f;
    //Z座標の最小値
    public float zMinPosition = -1f;
    //Z座標の最大値
    public float zMaxPosition = 1f;
    //敵生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;
    //敵の生成数
    private int EnemyCount = 0;
    //撃墜数
    private int DestroyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        //Wave1

        //撃破カウンター
        if (DestroyCount <= 3)
        {
            //3体目までのEnemyが出てきたか
            if (EnemyCount < 3)
            {
                //時間計測
                time += Time.deltaTime;
                //経過時間が生成時間になったとき(生成時間より大きくなったとき)
                if (time > interval)
                {
                    number = Random.Range(0, enemyPrefab.Length);
                    //enemyをインスタンス化する(生成する)
                    GameObject enemy = Instantiate(enemyPrefab[number]);
                    //生成した敵の位置をランダムに設定する
                    enemy.transform.position = GetRandomPosition();
                    //経過時間を初期化して再度時間計測を始める
                    time = 0f;
                    //次に発生する時間間隔を決定する
                    interval = GetRandomTime();
                    //生成カウンター
                    EnemyCount += 1;
                }
            }
        }

        //Wave2

        //撃破カウンター
        if (3 <= DestroyCount && DestroyCount <= 7)
        {
            //7体目までのEnemyが出てきたか
            if (EnemyCount < 7)
            {
                //時間計測
                time += Time.deltaTime;
                //経過時間が生成時間になったとき(生成時間より大きくなったとき)
                if (time > interval)
                {
                    number = Random.Range(0, enemyPrefab.Length);
                    //enemyをインスタンス化する(生成する)
                    GameObject enemy = Instantiate(enemyPrefab[number]);
                    //生成した敵の位置をランダムに設定する
                    enemy.transform.position = GetRandomPosition();
                    //経過時間を初期化して再度時間計測を始める
                    time = 0f;
                    //次に発生する時間間隔を決定する
                    interval = GetRandomTime();
                    //生成カウンター
                    EnemyCount += 1;
                }
            }
        }
    }

    public void CountDestroy()
    {
        DestroyCount += 1;
    }

    //ランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
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