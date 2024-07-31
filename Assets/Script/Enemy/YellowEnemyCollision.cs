using UnityEngine;

public class YellowEnemyCollision : MonoBehaviour
{
    [Header("黄色の赤色の方の弱点のOnバージョンimageを取得"), SerializeField]
    private GameObject Effective_Colour_Red_On;

    [Header("黄色の赤色の方の弱点のOffバージョンimageを取得"), SerializeField]
    private GameObject Effective_Colour_Red_Off;

    [Header("黄色の緑色の方の弱点のOnバージョンimageを取得"), SerializeField]
    private GameObject Effective_Colour_Green_On;

    [Header("黄色の緑色の方の弱点のOffバージョンimageを取得"), SerializeField]
    private GameObject Effective_Colour_Green_Off;

    [Tooltip("緑のライトが当たっているかを判定")]
    private bool Green_Attack_Flag;

    [Tooltip("赤色のライトが当たっているかを判定")]
    private bool Red_Attack_Flag;

    [Tooltip("緑色のライトが当たっているかを判定")]
    private GreenLightCollision Player_Green_Flag;

    [Header(""), SerializeField]
    private ParticleSystem particle;

    [Tooltip("")]
    private ParticleSystem newParticle;

    [Tooltip("")]
    private bool ParticleSystem;

    [Tooltip("EnemyのHpを入れておく"),SerializeField]
    private int Enemy_Hp;

    [Tooltip("")]
    private float Enemy_Hit_Time = 1.1f;

    [Tooltip("")]
    private const float Hit_Cool_Time = 1;


    [Tooltip("自分が死んだかどうかを判定検知する")]
    private bool Enemy_Destory_flag;

    [Tooltip("")]
    private float Enemy_Destroy_Time;

    [Header(""), SerializeField]
    private WaveSystem Wave_System;

    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing Monster_Date_Array;

    public float Shrink_Speed = 0.5f;
    private const float ROTATION_SPEED = 4000.0f;

    [Tooltip("MonsterDateの何番目のデータ呼ぶか")]
    private const int ENEMY_DATE_NUMBER = 3;

    private void Awake()
    {
        Effective_Colour_Red_On.SetActive(false);
        Effective_Colour_Green_On.SetActive(false);
    }


    private void Start()
    {
        Green_Attack_Flag = false;
        Red_Attack_Flag = false;
        ParticleSystem = false;
        Wave_System = GameObject.FindObjectOfType<WaveSystem>();
        Enemy_Hp = Monster_Date_Array.monsterData[ENEMY_DATE_NUMBER].Hp;
    }

    void Update()
    {
        if (Red_Attack_Flag && Green_Attack_Flag && Player_Green_Flag.yellowAttackFlag)
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
            Player_Green_Flag = other.gameObject.GetComponent<GreenLightCollision>();
            Effective_Colour_Green_On.SetActive(true);
            Effective_Colour_Green_Off.SetActive(false);
        }

        if (other.gameObject.CompareTag("redlight"))
        {
            Red_Attack_Flag = true;

            Effective_Colour_Red_On.SetActive(true);
            Effective_Colour_Red_Off.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("greenlight"))
        {
            Green_Attack_Flag = false;
            ParticleSystem = false;
            Destroy(newParticle);
            Effective_Colour_Green_On.SetActive(false);
            Effective_Colour_Green_Off.SetActive(true);
        }

        if (other.gameObject.CompareTag("redlight"))
        {
            Red_Attack_Flag = false;
            ParticleSystem = false;
            Destroy(newParticle);

            Effective_Colour_Red_On.SetActive(false);
            Effective_Colour_Red_Off.SetActive(true);
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
