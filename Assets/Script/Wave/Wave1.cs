using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;

    [Header("単色の敵"), SerializeField]
    public GameObject[] Enemies;

    [Header("中ボス"), SerializeField]
    public GameObject[] MediumBoss;

    [SerializeField]
    private int EnemyCrushingWave1Count = 0;

    [SerializeField]
    private int EnemySpawnCount = 0;

    [Header("kokokok"), SerializeField]
    private int EnemyCrushing;

    //撃破カウンターWave1
    private int wave1Count = 0;

    //Enemy数
    private int EnemyCount = 0;

    //Medium Boss数
    private int MediumBossCount = 0;

    //BossBattleEnemy数
    private int BossBattleCount = 0;

    //BossBattleのEnemy出現Time
    private float BossBattleTime = 0.0f;

    private bool EnemySpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCount = 0;
        wave1Count = 0;
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

    void Update()
    {
        if (EnemyCount == 1 && wave1Count == 1)
        {
            EnemySystem.WaveInterval1();
        }

        if(MediumBossCount >= 1)
        {
            BossBattleTime += Time.deltaTime;
            EnemySpawn = true;
        }

        Debug.Log(EnemyCrushingWave1Count);
    }

    //Enemiesの出現
    public void wave1()
    {
        if (!EnemySpawn)
        {
            if (EnemySpawnCount == 0)
            {
                for (int i = 0; i < 6; ++i)
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
                    var ghosts = GameObject.FindGameObjectsWithTag("EnemyW1");
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

        //中ボス戦
        if (EnemyCrushingWave1Count >= 20 && MediumBossCount < 1)
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

            //中ボスと一緒に出てくるEnemy
            for (int i = 0; i < 4; ++i)
            {
                //enemyをインスタンス化する(生成する)
                //生成した敵の位置をランダムに設定する
                var rightTopEne = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
                var leftBottomEne = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

                // rightTop xが右端　yが上端                
                // leftbottom xが左端　yが下端
                var randomPosXEne = Random.Range(leftBottomEne.z, rightTopEne.z);
                var randomPosZEne = Random.Range(leftBottomEne.x, rightTopEne.x);

                GameObject enemyEne = Instantiate(Enemies[i]);
                enemyEne.transform.position = new Vector3(randomPosXEne, 3, randomPosZEne);
                ++MediumBossCount;
            }
        }

        //時間経過で出現するEnemy
        if(BossBattleTime >= 6.0f && EnemyCrushingWave1Count >= 20 && BossBattleCount == 0)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop xが右端　yが上端                
            // leftbottom xが左端　yが下端
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemyEnemy = Instantiate(Enemies[Random.Range(0, 3)]);
            enemyEnemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);

            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTopEnemy2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottomEnemy2 = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop xが右端　yが上端                
            // leftbottom xが左端　yが下端
            var randomPosXEnemy2 = Random.Range(leftBottomEnemy2.z, rightTopEnemy2.z);
            var randomPosZEnemy2 = Random.Range(leftBottomEnemy2.x, rightTopEnemy2.x);

            GameObject enemyEnemy2 = Instantiate(Enemies[Random.Range(0, 3)]);
            enemyEnemy2.transform.position = new Vector3(randomPosXEnemy2, 3, randomPosZEnemy2);

            ++BossBattleCount;
            BossBattleTime = 0;
        }

        if (BossBattleTime >= 4.0f && EnemyCrushingWave1Count >= 20 && BossBattleCount < 10)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop xが右端　yが上端                
            // leftbottom xが左端　yが下端
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemyEnemy = Instantiate(Enemies[Random.Range(0, 3)]);
            enemyEnemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);

            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var rightTopEnemy2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottomEnemy2 = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop xが右端　yが上端                
            // leftbottom xが左端　yが下端
            var randomPosXEnemy2 = Random.Range(leftBottomEnemy2.z, rightTopEnemy2.z);
            var randomPosZEnemy2 = Random.Range(leftBottomEnemy2.x, rightTopEnemy2.x);

            GameObject enemyEnemy2 = Instantiate(Enemies[Random.Range(0, 3)]);
            enemyEnemy2.transform.position = new Vector3(randomPosXEnemy2, 3, randomPosZEnemy2);

            ++BossBattleCount;
            BossBattleTime = 0;
        }
    }

    public void CountW1()
    {
        ++EnemyCrushingWave1Count;
    }
}
