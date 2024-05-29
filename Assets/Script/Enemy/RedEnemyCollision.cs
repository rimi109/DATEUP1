using UnityEngine;

public class RedEnemyCollision : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem particle;

    [Tooltip("")]
    private ParticleSystem newParticle;

    [Tooltip("赤色のライトが当たっているかを判定")]
    private bool Red_Attack_Flag;

    [Tooltip("自分が死んだかどうかを判定検知する")]
    private bool Enemy_Destory_flag;

    [Tooltip("")]
    private bool ParticleSystem;

    [Header("WhiteのHpを設定"), SerializeField]
    private int Red_Enemy_Hp;

    [Tooltip("")]
    private float Enemy_Hit_Time = 1.1f;

    [Tooltip("")]
    private const float Hit_Cool_Time = 1;

    public PlayerScript targetR;

    [Tooltip("")]
    private float Enemy_Destroy_Time;

    public float Shrink_Speed = 0.5f;
    private const float ROTATION_SPEED = 4000.0f;

    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing Monster_Date_Array;

    [Tooltip("MonsterDateの何番目のデータ呼ぶか")]
    private const int ENEMY_DATE_NUMBER = 0;

    private void Start()
    {
        Red_Attack_Flag = false;
        ParticleSystem = false;

        targetR = GameObject.FindObjectOfType<PlayerScript>();
        Monster_Date_Array = GameObject.FindObjectOfType<CSVProcessing>();
    }

    void Update()
    {
        if (Red_Attack_Flag)
        {
            Enemy_Hit_Time += Time.deltaTime;

            if (Enemy_Hit_Time > Hit_Cool_Time)
            {
                Monster_Date_Array.Monster_Data[ENEMY_DATE_NUMBER].Hp -= 1;
                Enemy_Hit_Time = 0;
                if (Monster_Date_Array.Monster_Data[ENEMY_DATE_NUMBER].Hp <= 0)
                {
                    Enemy_Destory_flag = true;
                    targetR.Wave1EnemyDestroy();
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
                Destroy(newParticle);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("redlight"))
        {
            Red_Attack_Flag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("redlight"))
        {
            Red_Attack_Flag = false;
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
