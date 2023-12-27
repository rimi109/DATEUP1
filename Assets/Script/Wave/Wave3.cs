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

    [Header("単色の敵"), SerializeField]
    public GameObject[] Enemies;

    [Header("複色"), SerializeField]
    public GameObject[] MediumBoss;

    //撃破カウンターWave1
    private float wave3Count = 0;
    //Enemyのインターバル
    private float EnemyIn = 0.0f;
    //Enemy数
    private float EnemyCount = 0;

    [SerializeField]
    private int EnemyCrushingWave3Count = 0;

    [SerializeField]
    private int EnemySpawnCount = 0;

    //Boss数
    private int BossCount = 0;

    private int MediumCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Shuffle(Enemies);
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
        EnemyIn += Time.deltaTime;
    }

    //Enemiesの出現
    public void wave3()
    {
        //BOSS
        if (EnemyIn >= 5.0f && BossCount == 0)
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
            ++BossCount;
        }

        //単色
        if (EnemySpawnCount == 0)
        {
            if (EnemyIn >= 7.0f && EnemySpawnCount < 3)
            {
                for (int i = 0; i < 3; ++i)
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

                //enemyをインスタンス化する(生成する)
                //生成した敵の位置をランダムに設定する
                var rightTopEne = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
                var leftBottomEne = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

                // rightTop xが右端　yが上端                
                // leftbottom xが左端　yが下端
                var randomPosXEne = Random.Range(leftBottomEne.z, rightTopEne.z);
                var randomPosZEne = Random.Range(leftBottomEne.x, rightTopEne.x);

                GameObject enemyEne = Instantiate(Enemies[Random.Range(0, 3)]);
                enemyEne.transform.position = new Vector3(randomPosXEne, 3, randomPosZEne);
            }
        }
        else
        {
            if (EnemySpawnCount < 100)
            {
                var ghosts = GameObject.FindGameObjectsWithTag("EnemyW3");
                if (ghosts.Length < 4)
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

        //複色
        if(EnemyIn >= 10.0f)
        {
            if (MediumCount == 0)
            {
                //enemyをインスタンス化する(生成する)
                //生成した敵の位置をランダムに設定する
                var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
                var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

                // rightTop xが右端　yが上端                
                // leftbottom xが左端　yが下端
                var randomPosX = Random.Range(leftBottom.z, rightTop.z);
                var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

                GameObject enemy = Instantiate(MediumBoss[Random.Range(0, 3)]);
                enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
                ++MediumCount;
            }
            else
            {
                if (EnemySpawnCount < 100)
                {
                    var ghosts = GameObject.FindGameObjectsWithTag("EnemyW2");
                    if (ghosts.Length < 1)
                    {
                        //enemyをインスタンス化する(生成する)
                        //生成した敵の位置をランダムに設定する
                        var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
                        var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

                        // rightTop xが右端　yが上端                
                        // leftbottom xが左端　yが下端
                        var randomPosX = Random.Range(leftBottom.z, rightTop.z);
                        var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

                        GameObject enemy = Instantiate(MediumBoss[Random.Range(0, 3)]);
                        enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
                        ++MediumCount;
                    }
                }
            }
        }
    }

    public void CountW3()
    {
        wave3Count += 1;
    }
}
