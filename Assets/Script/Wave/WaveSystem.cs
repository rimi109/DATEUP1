using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class WaveSystem : MonoBehaviour
{
    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing Wave_Date_Array;

    [Header("全種類の敵を取得"), SerializeField]
    private GameObject[] Enemy_S;

    [Tooltip("Enemyの湧いた数を数える"),SerializeField]
    private int Spawn_Count;

    [Header("Wave1の敵の最大個数"),SerializeField]
    private int Wave1_Max_Spawn;

    [Header("Wave2の敵の最大個数"),SerializeField]
    private int Wave2_Spawn_Count;

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

        if (Spawn_Count >= Wave1_Max_Spawn)
            return;
        Enemy_Spawn_Coordinate();
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

        var waveDate = Wave_Date_Array.Wave_Date;
        int enemyValue;

        for (int i = 0; i < waveDate.Length; i++)
        {
            enemyValue = Enemy_Dictionary[waveDate[i].wave1];

            //enemyをインスタンス化する(生成する)
            //生成した敵の位置をランダムに設定する
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemy_S[enemyValue]);
            enemy.transform.position = new Vector3(randomPosX, ENEMY_CAVEIN_Y, randomPosZ);

            Spawn_Count++;
        }
    }
    #endregion

}
