using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing Date_Array;

    [Header("全種類の敵を取得"), SerializeField]
    private GameObject[] Enemy_S;

    [Tooltip("Enemyの湧いた数を数える")]
    private int Wave1_Spawn_Count;

    [Tooltip("Enemyの湧いた数を数える")]
    private int Wave2_Spawn_Count;

    [Tooltip("Enemyの湧いた数を数える")]
    private int Wave3_Spawn_Count;

    [Tooltip("敵が何対倒されたかを数える")]
    private int Enemy_Destroy_Count;

    [Tooltip("Switch文のケースの値")]
    private int Wave_Switch_Nunber;

    [Tooltip("一体づつ出現する敵かどうかを確認する")]
    private const int ENEMY_SPWAN_SOLO_VALUE = 1;

    [Tooltip("Enemyが地面にめり込まないようにY軸を変更")]
    private const int ENEMY_CAVEIN_Y = 3;

    [Tooltip("カメラのRight座標をを少し変更し画面内に出現させる")]
    private const float RIGHT_TOP_CAMERA_COORDINATES_MINUS = 50.0f;

    [Tooltip("カメラのBottom座標をを少し変更し画面内に出現させる")]
    private const float LEFT_BOTTOM_CAMERA_COORDINATES_MINUS = 100.0f;

    [Tooltip("敵が死んだかどうかを確認")]
    private bool Enemy_Destroy_Flag;


    Dictionary<string, int> Enemy_Dictionary = new Dictionary<string, int>()
    {
        {"BlueEnemy",0},
        {"RedEnemy",1},
        {"GreenEnemy",2},
        {"YellowEnemy",3},
        {"LightBlueEnemy",4},
        {"PurpleEnemy",5},
        {"Boss",6},
    };

private void Update()
    {
            switch (Wave_Switch_Nunber) { 
             case  0:
                    if (Wave1_Spawn_Count < Date_Array.Enemy_Spawn_Max_Date[0].Wave1MaxEnemy)
                    {
                        Enemy_Spawn_Coordinate();
                    }

                    if (Enemy_Destroy_Count >= Date_Array.Enemy_Spawn_Max_Date[0].Wave1MaxEnemy)
                    {
                        Date_Array.Wave_2();
                        Wave_Switch_Nunber++;
                        Enemy_Destroy_Count = 0;
                    }

                break;

             case 1:
                    if (Wave2_Spawn_Count < Date_Array.Enemy_Spawn_Max_Date[0].Wave2MaxEnemy)
                    {
                      
                        Enemy_Spawn_Coordinate();
                        
                    }

                    if(Enemy_Destroy_Count >= Date_Array.Enemy_Spawn_Max_Date[0].Wave2MaxEnemy)
                    {
                        Date_Array.Wave_3();
                        Wave_Switch_Nunber++;
                        Enemy_Destroy_Count = 0;
                    }
                break;

             case 2:
                    if (Wave3_Spawn_Count < Date_Array.Enemy_Spawn_Max_Date[0].Wave3MaxEnemy)
                    {              
                        Enemy_Spawn_Coordinate();
                    }
                break;
            }
   
    }

    #region EnemyがSpawnする際にEnemyが出現する座標をRandomで決めるための関数
    /// <summary>
    /// EnemyがSpawnする際にEnemyが出現する座標をrandomで決めるための関数
    /// </summary>
    private void Enemy_Spawn_Coordinate()
    {
        switch (Wave_Switch_Nunber) {
            case 0:

                Wave1_Spwan_Function();

                break;
               
            case 1:

                Wave2_Spwan_Function();

                break;

            case 2:

                Wave3_Spwan_Function();

                break;
        }
    }
    #endregion

    #region Wave1に出現する敵を設定
    /// <summary>
    /// Wave1に出現する敵を設定
    /// </summary>
    private void Wave1_Spwan_Function()
    {
        //MaineCameraの座標を設定
        var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
            Camera.main.farClipPlane - RIGHT_TOP_CAMERA_COORDINATES_MINUS));
        var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0,
            Camera.main.farClipPlane - LEFT_BOTTOM_CAMERA_COORDINATES_MINUS));

       //MaineCameraの座標内をRandomで値を決める
        var randomPosX = Random.Range(leftBottom.z, rightTop.z);
        var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

        var waveDate = Date_Array.Wave_Date;
        int enemyValue;
        int enemySpawnWave1Value;

        enemyValue = Enemy_Dictionary[waveDate[Wave1_Spawn_Count].wave1];
        enemySpawnWave1Value = waveDate[Wave1_Spawn_Count].Wave1SpawnPutter;

        if (enemySpawnWave1Value == 0)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject wave1Enemy = Instantiate(Enemy_S[enemyValue]);
            wave1Enemy.transform.position = new Vector3(randomPosX, ENEMY_CAVEIN_Y, randomPosZ);
            Wave1_Spawn_Count++;
        }

        if (enemySpawnWave1Value == ENEMY_SPWAN_SOLO_VALUE && Enemy_Destroy_Flag)
        {
            GameObject wave1Enemy = Instantiate(Enemy_S[enemyValue]);
            wave1Enemy.transform.position = new Vector3(randomPosX, ENEMY_CAVEIN_Y, randomPosZ);
            Wave1_Spawn_Count++;
            Enemy_Destroy_Flag = false;
        }
    }
    #endregion

    #region Wave2に出現する敵を設定
    /// <summary>
    /// Wave2に出現する敵を設定
    /// </summary>
    private void Wave2_Spwan_Function()
    {
        var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
            Camera.main.farClipPlane - RIGHT_TOP_CAMERA_COORDINATES_MINUS));

        var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0,
            Camera.main.farClipPlane - LEFT_BOTTOM_CAMERA_COORDINATES_MINUS));

        var randomPosX = Random.Range(leftBottom.z, rightTop.z);
        var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

        var waveDate = Date_Array.Wave_Date;
        int enemyValue;
        int enemySpawnWave2Value = waveDate[Wave2_Spawn_Count].Wave2SpwanPutter;
        if (enemySpawnWave2Value == 0)
        {
            enemyValue = Enemy_Dictionary[waveDate[Wave2_Spawn_Count].wave2];
            GameObject wave2Enemy = Instantiate(Enemy_S[enemyValue]);
            wave2Enemy.transform.position = new Vector3(randomPosX, ENEMY_CAVEIN_Y, randomPosZ);
            Wave2_Spawn_Count++;
        }

        if (enemySpawnWave2Value == ENEMY_SPWAN_SOLO_VALUE && Enemy_Destroy_Flag)
        {
            enemyValue = Enemy_Dictionary[waveDate[Wave2_Spawn_Count].wave2];
            GameObject wave2Enemy = Instantiate(Enemy_S[enemyValue]);
            wave2Enemy.transform.position = new Vector3(randomPosX, ENEMY_CAVEIN_Y, randomPosZ);
            Wave2_Spawn_Count++;
            Enemy_Destroy_Flag = false;
        }
    }
    #endregion

    #region Wave3に出現する敵を設定
    /// <summary>
    /// Wave3に出現する敵を設定
    /// </summary>
    private void Wave3_Spwan_Function()
    {

        var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
            Camera.main.farClipPlane - RIGHT_TOP_CAMERA_COORDINATES_MINUS));

        var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0,
            Camera.main.farClipPlane - LEFT_BOTTOM_CAMERA_COORDINATES_MINUS));

        var randomPosX = Random.Range(leftBottom.z, rightTop.z);
        var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

        var waveDate = Date_Array.Wave_Date;
        int enemyValue;
        int enemySpawnWave3Value = waveDate[Wave3_Spawn_Count].Wave3SpwanPutter;

        if (enemySpawnWave3Value == 0)
        {
            enemyValue = Enemy_Dictionary[waveDate[Wave3_Spawn_Count].wave3];
            GameObject wave3Enemy = Instantiate(Enemy_S[enemyValue]);
            wave3Enemy.transform.position = new Vector3(randomPosX, ENEMY_CAVEIN_Y, randomPosZ);
            Wave3_Spawn_Count++;
        }

        if (enemySpawnWave3Value == ENEMY_SPWAN_SOLO_VALUE && Enemy_Destroy_Flag)
        {
            enemyValue = Enemy_Dictionary[waveDate[Wave3_Spawn_Count].wave3];
            GameObject wave3Enemy = Instantiate(Enemy_S[enemyValue]);
            wave3Enemy.transform.position = new Vector3(randomPosX, ENEMY_CAVEIN_Y, randomPosZ);
            Wave3_Spawn_Count++;
            Enemy_Destroy_Flag = false;
        }
    }
    #endregion

    #region 敵が死んだときにWaveを進める
    /// <summary>
    /// 敵が死んだときにWaveを進める
    /// </summary>
    public void Enemy_Destroy_Count_System()
    {
        Enemy_Destroy_Count++;
        Enemy_Destroy_Flag = true;
    }
    #endregion
}
