using UnityEngine;

public class GreenEnemyCollision : MonoBehaviour
{

    [Tooltip("青色のライトが当たっているかを判定")]
    private bool Green_Attack_Flag;

    [SerializeField]
    private ParticleSystem particle;

    [Tooltip("")]
    private ParticleSystem newParticle;

    [Tooltip("")]
    private bool ParticleSystem;

    [Tooltip("")]
    private float Enemy_Hit_Time = 1.1f;

    [Tooltip("")]
    private const float Hit_Cool_Time = 1;

    [Header("CSVからデータを取得"),SerializeField]
    private CSVProcessing Monster_Date_Array;

    [Tooltip("自分が死んだかどうかを判定検知する")]
    private bool Enemy_Destory_flag;

    [Tooltip("")]
    private float Enemy_Destroy_Time;


    public float Shrink_Speed = 0.5f;

    private const float ROTATION_SPEED = 4000.0f;

    [Tooltip("EnemyのHpを入れておく")]
    private int Enemy_Hp;

    [Tooltip("MonsterDateの何番目のデータ呼ぶか")]
    private const int ENEMY_DATE_NUMBER = 2;

    [Header(""), SerializeField]
    private WaveSystem Wave_System;


    private void Start()
    {
        Green_Attack_Flag = false;
        ParticleSystem = false;
        Monster_Date_Array = GameObject.FindObjectOfType<CSVProcessing>();
        Wave_System = GameObject.FindObjectOfType<WaveSystem>();
        Enemy_Hp = Monster_Date_Array.monsterData[ENEMY_DATE_NUMBER].Hp;
    }

    void Update()
    {
        if (Green_Attack_Flag)
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

            if (!ParticleSystem)
            {
                newParticle = Instantiate(particle);
                newParticle.Play();
                ParticleSystem = true;
            }
            else
            {
                newParticle.transform.position = this.transform.position;
            }
        }

        if (Enemy_Destory_flag)
        {
            Enemy_destroy_animation();
            Enemy_Destroy_Time += Time.deltaTime;
            if (Enemy_Destroy_Time > 1)
            {
                Wave_System.EnemyDestroyCountSystem();
                Destroy(newParticle);
                Destroy(this.gameObject);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("greenlight"))
        {
            Green_Attack_Flag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("greenlight"))
        {
            Green_Attack_Flag = false;
            ParticleSystem = false;
            Destroy(newParticle);
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
