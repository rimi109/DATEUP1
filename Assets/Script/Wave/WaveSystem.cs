using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing dateArray;

    [Header("全種類の敵を取得"), SerializeField]
    private GameObject[] enemyS;

    [Tooltip("Enemyの湧いた数を数える")]
    private int waveSpawnCount;

    [Tooltip("敵が何対倒されたかを数える")]
    private int enemyDestroyCount;

    [Tooltip("Switch文のケースの値")]
    private int waveSwitchNunber;

    [Tooltip("一体づつ出現する敵かどうかを確認する")]
    private const int ENEMY_SPWAN_SOLO_VALUE = 1;

    [Tooltip("Enemyが地面にめり込まないようにY軸を変更")]
    private const int ENEMY_CAVEIN_Y = 3;

    [Tooltip("カメラのRight座標をを少し変更し画面内に出現させる")]
    private const float RIGHT_TOP_CAMERA_COORDINATES_MINUS = 50.0f;

    [Tooltip("カメラのBottom座標をを少し変更し画面内に出現させる")]
    private const float LEFT_BOTTOM_CAMERA_COORDINATES_MINUS = 100.0f;

    [Tooltip("敵が死んだかどうかを確認")]
    private bool enemyDestroyFlag;


    Dictionary<string, int> EnemyDictionary = new Dictionary<string, int>()
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
            switch (waveSwitchNunber) { 
             case  0:
                    if (waveSpawnCount < dateArray.enemySpawnMaxDate[0].Wave1MaxEnemy)
                    {
                         waveSpwanFunction();
                    }

                    if (enemyDestroyCount >= dateArray.enemySpawnMaxDate[0].Wave1MaxEnemy)
                    {
                        dateArray.Wave2();
                        waveSwitchNunber++;
                        waveSpawnCount = 0;
                        enemyDestroyCount = 0;
                    }

                break;

             case 1:
                    if (waveSpawnCount < dateArray.enemySpawnMaxDate[0].Wave2MaxEnemy)
                    {

                        waveSpwanFunction();
                        
                    }

                    if(enemyDestroyCount >= dateArray.enemySpawnMaxDate[0].Wave2MaxEnemy)
                    {
                        dateArray.Wave3();
                        waveSwitchNunber++;
                        waveSpawnCount = 0;
                        enemyDestroyCount = 0;
                    }
                break;

             case 2:
                    if (waveSpawnCount < dateArray.enemySpawnMaxDate[0].Wave3MaxEnemy)
                    {
                      waveSpwanFunction();
                    }
                break;
            }
   
    }

    #region Waveで出現する敵を設定
    /// <summary>
    /// Waveで出現する敵を設定
    /// </summary>
    private void waveSpwanFunction()
    {
        //MaineCameraの座標を設定
        var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
            Camera.main.farClipPlane - RIGHT_TOP_CAMERA_COORDINATES_MINUS));
        var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0,
            Camera.main.farClipPlane - LEFT_BOTTOM_CAMERA_COORDINATES_MINUS));

       //MaineCameraの座標内をRandomで値を決める
        var randomPosX = Random.Range(leftBottom.z, rightTop.z);
        var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

        var waveDate = dateArray.waveDate;
        int enemyValue;
        int enemySpawnWaveValue;

        enemyValue = EnemyDictionary[waveDate[waveSpawnCount].wave];
        enemySpawnWaveValue = waveDate[waveSpawnCount].WaveSpawnPutter;

        if (enemySpawnWaveValue == 0)
        {
            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            GameObject waveEnemy = Instantiate(enemyS[enemyValue]);
            waveEnemy.transform.position = new Vector3(randomPosX, ENEMY_CAVEIN_Y, randomPosZ);
            waveSpawnCount++;
        }

        if (enemySpawnWaveValue == ENEMY_SPWAN_SOLO_VALUE && enemyDestroyFlag)
        {
            GameObject waveEnemy = Instantiate(enemyS[enemyValue]);
            waveEnemy.transform.position = new Vector3(randomPosX, ENEMY_CAVEIN_Y, randomPosZ);
            waveSpawnCount++;
            enemyDestroyFlag = false;
        }
    }
    #endregion

    #region 敵が死んだときにWaveを進める
    /// <summary>
    /// 敵が死んだときにWaveを進める
    /// </summary>
    public void EnemyDestroyCountSystem()
    {
        enemyDestroyCount++;
        enemyDestroyFlag = true;
    }
    #endregion
}
