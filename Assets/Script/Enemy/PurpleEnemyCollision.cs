using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemyCollision : MonoBehaviour
{

    [Header("紫色の赤色の方の弱点のOnバージョンimageを取得"),SerializeField]
    private GameObject Effective_Colour_Red_On;

    [Header("紫色の赤色の方の弱点のOffバージョンimageを取得"), SerializeField]
    private GameObject Effective_Colour_Red_Off;

    [Header("紫色の青色の方の弱点のOnバージョンimageを取得"), SerializeField]
    private GameObject Effective_Colour_Blue_On;

    [Header("紫色の青色の方の弱点のOffバージョンimageを取得"), SerializeField]
    private GameObject Effective_Colour_Blue_Off;

    [Tooltip("赤色のライトが当たっているかを判定")]
    private bool Red_Attack_Flag;

    [Tooltip("青色のライトが当たっているかを判定")]
    private bool Blue_Attack_Flag;

    [Tooltip("紫色のライトが当たっているかを判定")]
    private RedLightCollision Player_Purple_Flag;

    [Tooltip("")]
    private bool ParticleSystem;

    [Header("WhiteのHpを設定"), SerializeField]
    private int Purple_Enemy_Hp;

    [Tooltip("")]
    private float Enemy_Hit_Time = 1.1f;

    [Tooltip("")]
    private const float Hit_Cool_Time = 1;

    [SerializeField]
    private ParticleSystem particle;

    [Tooltip("")]
    private ParticleSystem newParticle;

    public PlayerScript Target_Player;

    private void Start()
    {
        Red_Attack_Flag  = false;
        Blue_Attack_Flag = false;
        ParticleSystem   = false;

        Target_Player = GameObject.FindObjectOfType<PlayerScript>();
    }

    void Update()
    {
        if (Blue_Attack_Flag && Red_Attack_Flag && Player_Purple_Flag.Purple_Attack_Flag)
        {
            Enemy_Hit_Time += Time.deltaTime;

            if (Enemy_Hit_Time > Hit_Cool_Time)
            {
                Purple_Enemy_Hp -= 2;
                Debug.Log(Purple_Enemy_Hp);
                Enemy_Hit_Time = 0;
                if (Purple_Enemy_Hp <= 0)
                {
                    Destroy(newParticle);
                    Destroy(this.gameObject);
                    Target_Player.Wave2EnemyDestroy();
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
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("redlight"))
        {
            Effective_Colour_Red_On.SetActive(true);
            Effective_Colour_Red_Off.SetActive(true);
            Red_Attack_Flag = true;
            Player_Purple_Flag = other.gameObject.GetComponent<RedLightCollision>();
        }

        if (other.gameObject.CompareTag("bluelight"))
        {
            Blue_Attack_Flag = true;
            Effective_Colour_Blue_On.SetActive(true);
            Effective_Colour_Blue_Off.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("redlight"))
        {
            Red_Attack_Flag = false;
            ParticleSystem = false;
            Destroy(newParticle);
            Effective_Colour_Red_On.SetActive(false);
            Effective_Colour_Red_Off.SetActive(true);
        }

        if (other.gameObject.CompareTag("bluelight"))
        {
            Blue_Attack_Flag = false;
            ParticleSystem = false;
            Destroy(newParticle);
            Effective_Colour_Blue_On.SetActive(false);
            Effective_Colour_Blue_Off.SetActive(true);
        }
    }
}
