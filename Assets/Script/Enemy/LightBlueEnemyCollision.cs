using UnityEngine;

public class LightBlueEnemyCollision : MonoBehaviour
{

    [Header("自分のゲームオブジェクトを取得"), SerializeField]
    private GameObject thisEnemy;

    [Header("水色の緑色の方の弱点のOnバージョンimageを取得"), SerializeField]
    private GameObject Effective_Colour_Green_On;

    [Header("水色の緑色の方の弱点のOffバージョンimageを取得"), SerializeField]
    private GameObject Effective_Colour_Green_Off;

    [Header("水色の青色の方の弱点のOnバージョンimageを取得"), SerializeField]
    private GameObject Effective_Colour_Blue_On;

    [Header("紫色の青色の方の弱点のOffバージョンimageを取得"), SerializeField]
    private GameObject Effective_Colour_Blue_Off;

    [Tooltip("緑色のライトが当たっているかを判定")]
    private bool Green_Attack_Flag;

    [Tooltip("青色のライトが当たっているかを判定")]
    private bool Blue_Attack_Flag;

    [Tooltip("水色のライトが当たっているかを判定")]
    private BlueLightCollision Player_Light_Blue_Flag;

    [SerializeField]
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

    public float Shrink_Speed = 0.5f;
    private const float ROTATION_SPEED = 4000.0f;

    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing Monster_Date_Array;

    [Header(""), SerializeField]
    private WaveSystem Wave_System;

    [Tooltip("MonsterDateの何番目のデータ呼ぶか")]
    private const int ENEMY_DATE_NUMBER = 4;

    private void Awake()
    {
        Effective_Colour_Blue_On.SetActive(false);
        Effective_Colour_Green_On.SetActive(false);
    }

    private void Start()
    {
        Green_Attack_Flag = false;
        Blue_Attack_Flag = false;
        ParticleSystem = false;
        Wave_System = GameObject.FindObjectOfType<WaveSystem>();
        Enemy_Hp = Monster_Date_Array.monsterData[ENEMY_DATE_NUMBER].Hp;
    }

    void Update()
    {


        if (Blue_Attack_Flag && Green_Attack_Flag && Player_Light_Blue_Flag.Light_Blue_Attack_Flag)
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

        if (other.gameObject.CompareTag("bluelight"))
        {
            Player_Light_Blue_Flag = other.gameObject.GetComponent<BlueLightCollision>();
            Blue_Attack_Flag = true;
            Effective_Colour_Blue_On.SetActive(true);
            Effective_Colour_Blue_Off.SetActive(false);
        }

        if (other.gameObject.CompareTag("greenlight"))
        {
            Green_Attack_Flag = true;
            Effective_Colour_Green_On.SetActive(true);
            Effective_Colour_Green_Off.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("greenlight"))
        {
  
            
            ParticleSystem = false;
            Green_Attack_Flag = false;
            Effective_Colour_Green_On.SetActive(false);
            Effective_Colour_Green_Off.SetActive(true);
            Destroy(newParticle);
        }

        if (other.gameObject.CompareTag("bluelight"))
        {
            ParticleSystem = false;
            Blue_Attack_Flag = false;
            Effective_Colour_Blue_On.SetActive(false);
            Effective_Colour_Blue_Off.SetActive(true);
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
