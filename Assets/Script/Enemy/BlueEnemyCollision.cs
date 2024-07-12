using UnityEngine;

public class BlueEnemyCollision : MonoBehaviour
{
    [Tooltip("青色のライトが当たっているかを判定")]
    private bool Blue_Attack_Flag;

    [Tooltip("Particleを再生するかどうかを検知する")]
    private bool Particle_System;

    [Tooltip("自分が死んだかどうかを判定検知する")]
    private bool Enemy_Destory_flag;

    [Tooltip("Enemyが一秒ごとにダメージを")]
    private float Enemy_Hit_Time = 1.0f;

    [Tooltip("Enemyが連続でダメージを貰わないようにレキャストタイムを設定")]
    private const float Hit_Cool_Time = 1;

    [Tooltip("EnemyのHpを入れておく")]
    private int Enemy_Hp;

    [Tooltip("")]
    private float Enemy_Destroy_Time;

    public float Shrink_Speed = 0.5f;

    private const float ROTATION_SPEED = 4000.0f;

    [Header("Enemy自身で起きるPaticleを取得"), SerializeField]
    private ParticleSystem Enemy_Particle;

    [Tooltip("Enemy自身で起きるPaticleを取得")]
    private ParticleSystem Enemy_Formation;

    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing Monster_Date_Array;

    [Tooltip("MonsterDateの何番目のデータ呼ぶか")]
    private const int ENEMY_DATE_NUMBER = 1;

    [Header(""), SerializeField]
    private WaveSystem Wave_System;

    private void Start()
    {
        Blue_Attack_Flag = false;
        Particle_System = false;
        Enemy_Destory_flag = false;
        Monster_Date_Array = GameObject.FindObjectOfType<CSVProcessing>();
        Wave_System = GameObject.FindObjectOfType<WaveSystem>();
        Enemy_Hp = Monster_Date_Array.monsterData[ENEMY_DATE_NUMBER].Hp;
    }

    void Update()
    {
        if (Blue_Attack_Flag)
        {
            Enemy_Hit_Time += Time.deltaTime;

            if (Enemy_Hit_Time > Hit_Cool_Time)
            {

                Enemy_Hp -= 1;
                Enemy_Hit_Time = 0;
                if (Enemy_Hp <= 0)
                {
                    Enemy_Destory_flag = true;
                
                }
            }

            if (!Particle_System)
            {
                Enemy_Formation = Instantiate(Enemy_Particle);
                Enemy_Formation.Play();
                Particle_System = true;
            }
            else
            {
                Enemy_Formation.transform.position = this.transform.position;
            }
        }

        if (Enemy_Destory_flag)
        {
            Enemy_destroy_animation();
            Enemy_Destroy_Time += Time.deltaTime;
            if (Enemy_Destroy_Time > 1)
            {
                Wave_System.EnemyDestroyCountSystem();
                Destroy(Enemy_Formation);
                Destroy(this.gameObject);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("bluelight"))
        {
            Blue_Attack_Flag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("bluelight"))
        {
            Blue_Attack_Flag = false;
            Particle_System = false;
            Destroy(Enemy_Formation);
        }
    }

    private void Enemy_destroy_animation()
    {
        Vector3 currentScale = transform.localScale;
        float newScale = Mathf.Max(currentScale.x - Shrink_Speed, 0.0f);
        transform.localScale = new Vector3(newScale, newScale, newScale);

        Quaternion deltaRotation = Quaternion.Euler(0f, ROTATION_SPEED * Time.deltaTime, 0f);
        this.transform.rotation *= deltaRotation;
    }
}
