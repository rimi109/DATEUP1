using UnityEngine;
using System.Collections.Generic;

public class WaveSystem : MonoBehaviour
{
    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing Wave_Date_Array;

    [Header("全種類の敵を取得"), SerializeField]
    private GameObject[] Enemy_S;

    Dictionary<string, int> dic = new Dictionary<string, int>()
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
        Enemy_Spawn();
    }


    #region EnemyがSpawnする際にEnemyが出現する座標をrandomで決めるための関数
    /// <summary>
    /// EnemyがSpawnする際にEnemyが出現する座標をrandomで決めるための関数
    /// </summary>
    private void Enemy_Spawn()
    {
        //enemyをインスタンス化する(生成する)
        //生成した敵の位置をランダムに設定する
        var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
        var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

        // rightTop xが右端　yが上端                
        // leftbottom xが左端　yが下端
        var randomPosX = Random.Range(leftBottom.z, rightTop.z);
        var randomPosZ = Random.Range(leftBottom.x, rightTop.x);



        //GameObject enemy = Instantiate();

        //enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
    }
    #endregion

}
