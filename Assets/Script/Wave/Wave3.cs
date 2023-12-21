using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wave3 : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;
    //敵プレハブ白
    public GameObject enemyPrefabBoss;
    //敵リスト
    public GameObject[] Enemies = new GameObject[12];
    //撃破カウンターWave1
    private float wave3Count = 0;
    //Enemyのインターバル
    private float EnemyIn = 0.0f;
    //Enemy数
    private float EnemyCount = 0;

    [SerializeField]
    private int EnemyCrushingWave1Count = 0;

    [SerializeField]
    private int EnemySpawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Shuffle(Enemies);
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
        if (EnemyIn >= 5.0f)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop xが右端　yが上端                
            // leftbottom xが左端　yが下端
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(enemyPrefabBoss);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            ++EnemySpawnCount;
        }

        if (EnemySpawnCount == 1)
        {
            for (int i = 0; i < 12; ++i)
            {
                //enemyをインスタンス化する(生成する)
                //生成した敵の位置をランダムに設定する
                var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
                var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

                // rightTop xが右端　yが上端                
                // leftbottom xが左端　yが下端
                var randomPosX = Random.Range(leftBottom.z, rightTop.z);
                var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

                GameObject enemy = Instantiate(Enemies[EnemySpawnCount]);
                enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
                ++EnemySpawnCount;
            }
        }
        else
        {
            if (EnemySpawnCount < 20)
            {
                var ghosts = GameObject.FindGameObjectsWithTag("EnemyW3");
                if (ghosts.Length < 6)
                {
                    //enemyをインスタンス化する(生成する)
                    //生成した敵の位置をランダムに設定する
                    var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
                    var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

                    // rightTop xが右端　yが上端                
                    // leftbottom xが左端　yが下端
                    var randomPosX = Random.Range(leftBottom.z, rightTop.z);
                    var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

                    GameObject enemy = Instantiate(Enemies[Random.Range(0, 3)]);
                    enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
                    ++EnemySpawnCount;
                }
            }
        }

    }

    public void CountW3()
    {
        wave3Count += 1;
    }
}
