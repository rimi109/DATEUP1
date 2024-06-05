using UnityEngine;

public class WaveSystem : MonoBehaviour
{

    [Header("単色の敵"), SerializeField]
    public GameObject[] Enemies;

    [Header("中ボス"), SerializeField]
    public GameObject[] MediumBoss;

    [SerializeField]
    private int EnemyCrushingWave1Count = 0;

    [SerializeField]
    private int EnemySpawnCount = 0;

    [Header(""), SerializeField]
    private int EnemyCrushing;


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

        GameObject enemy = Instantiate(Enemies[EnemySpawnCount]);

        enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
    }
    #endregion

}
