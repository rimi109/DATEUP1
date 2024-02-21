using UnityEngine;

public class BlueEnemyCollision : MonoBehaviour
{
    [Tooltip("青色のライトが当たっているかを判定")]
    private bool Blue_Attack_Flag;

    [Tooltip("Particleを再生するかどうかを検知する")]
    private bool Particle_System;

    [Tooltip("自分が死んだかどうかを判定検知する")]
    private bool Enemy_Destory_flag;

    [Header("WhiteのHpを設定"), SerializeField]
    private int Blus_Enemy_Hp;

    [Tooltip("Enemyが一秒ごとにダメージを")]
    private float Enemy_Hit_Time = 1.0f;

    [Tooltip("Enemyが連続でダメージを貰わないようにレキャストタイムを設定")]
    private const float Hit_Cool_Time = 1;

    [Tooltip("")]
    private float Enemy_Destroy_Time;

    public float Shrink_Speed = 0.5f;
    private const float ROTATION_SPEED = 4000.0f;

    [Header("Enemy自身で起きるPaticleを取得"), SerializeField]
    private ParticleSystem Enemy_Particle;

    [Tooltip("Enemy自身で起きるPaticleを取得")]
    private ParticleSystem Enemy_Formation;

    public PlayerScript TargetR;

    private void Start()
    {
        Blue_Attack_Flag = false;
        Particle_System = false;
        Enemy_Destory_flag = false;
        TargetR = GameObject.FindObjectOfType<PlayerScript>();

    }

    void Update()
    {
        if (Blue_Attack_Flag)
        {
            Enemy_Hit_Time += Time.deltaTime;

            if (Enemy_Hit_Time > Hit_Cool_Time)
            {
                Blus_Enemy_Hp -= 1;
                Enemy_Hit_Time = 0;
                if (Blus_Enemy_Hp <= 0)
                {
                    Enemy_Destory_flag = true;
                    TargetR.Wave1EnemyDestroy();
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
