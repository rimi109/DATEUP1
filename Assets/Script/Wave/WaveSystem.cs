using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class WaveSystem : MonoBehaviour
{
    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing Date_Array;

    [Header("全種類の敵を取得"), SerializeField]
    private GameObject[] Enemy_S;

    [Tooltip("Enemyの湧いた数を数える")]
    private int Spawn_Count;

    [Tooltip("Enemyが地面にめり込まないようにY軸を変更")]
    private const int ENEMY_CAVEIN_Y = 3;

    [Tooltip("カメラのRight座標をを少し変更し画面内に出現させる")]
    private const float RIGHT_TOP_CAMERA_COORDINATES_MINUS = 50.0f;

    [Tooltip("カメラのBottom座標をを少し変更し画面内に出現させる")]
    private const float LEFT_BOTTOM_CAMERA_COORDINATES_MINUS = 100.0f;


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
     

            switch (0) { 
             case  0:
                    if (Spawn_Count < Date_Array.Enemy_Spawn_Max_Date[0].Wave1MaxEnemy)
                    {
                        Enemy_Spawn_Coordinate();
                    }

                        break;
             case 1:



                    break;
             case 2:




                    break;
            }
    
    }


    #region EnemyがSpawnする際にEnemyが出現する座標をRandomで決めるための関数
    /// <summary>
    /// EnemyがSpawnする際にEnemyが出現する座標をrandomで決めるための関数
    /// </summary>
    private void Enemy_Spawn_Coordinate()
    {
       
        var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
            Camera.main.farClipPlane - RIGHT_TOP_CAMERA_COORDINATES_MINUS));

        var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0,
            Camera.main.farClipPlane - LEFT_BOTTOM_CAMERA_COORDINATES_MINUS));

        var waveDate = Date_Array.Wave_Date;
        int enemyValue;
        enemyValue = Enemy_Dictionary[waveDate[Spawn_Count].wave1];

        //enemyをインスタンス化する(生成する)
        //生成した敵の位置をランダムに設定する
        var randomPosX = Random.Range(leftBottom.z, rightTop.z);
        var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

        GameObject enemy = Instantiate(Enemy_S[enemyValue]);
        enemy.transform.position = new Vector3(randomPosX, ENEMY_CAVEIN_Y, randomPosZ);
        Spawn_Count++;
    }
    #endregion
}
