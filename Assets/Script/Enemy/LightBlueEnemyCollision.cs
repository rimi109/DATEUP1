using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlueEnemyCollision : MonoBehaviour
{

    [Header("���F�̗ΐF�̕��̎�_��On�o�[�W����image���擾"), SerializeField]
    private GameObject Effective_Colour_Green_On;

    [Header("���F�̗ΐF�̕��̎�_��Off�o�[�W����image���擾"), SerializeField]
    private GameObject Effective_Colour_Green_Off;

    [Header("���F�̐F�̕��̎�_��On�o�[�W����image���擾"), SerializeField]
    private GameObject Effective_Colour_Blue_On;

    [Header("���F�̐F�̕��̎�_��Off�o�[�W����image���擾"), SerializeField]
    private GameObject Effective_Colour_Blue_Off;

    [Tooltip("�ΐF�̃��C�g���������Ă��邩�𔻒�")]
    private bool Green_Attack_Flag;

    [Tooltip("�F�̃��C�g���������Ă��邩�𔻒�")]
    private bool Blue_Attack_Flag;

    [Tooltip("���F�̃��C�g���������Ă��邩�𔻒�")]
    private BlueLightCollision Player_Light_Blue_Flag;

    [SerializeField]
    private ParticleSystem particle;

    [Tooltip("")]
    private ParticleSystem newParticle;

    [Tooltip("")]
    private bool ParticleSystem;

    [Header("White��Hp��ݒ�"), SerializeField]
    private int Purple_Enemy_Hp;

    [Tooltip("")]
    private float Enemy_Hit_Time = 1.1f;

    [Tooltip("")]
    private const float Hit_Cool_Time = 1;

    public PlayerScript targetR;


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
    
        targetR = GameObject.FindObjectOfType<PlayerScript>();

    }

    void Update()
    {
        if (Blue_Attack_Flag && Green_Attack_Flag && Player_Light_Blue_Flag.Light_Blue_Attack_Flag)
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
                    targetR.Wave2EnemyDestroy();
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
            Effective_Colour_Green_On.SetActive(false);
            Effective_Colour_Green_Off.SetActive(true);
            Green_Attack_Flag = false;
            ParticleSystem = false;
            Destroy(newParticle);
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
