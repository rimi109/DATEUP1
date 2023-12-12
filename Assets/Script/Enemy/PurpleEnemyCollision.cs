using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemyCollision : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;

    [Tooltip("�ԐF�̃��C�g���������Ă��邩�𔻒�")]
    private bool Red_Attack_Flag;

    [Tooltip("�F�̃��C�g���������Ă��邩�𔻒�")]
    private bool Blue_Attack_Flag;

    [Tooltip("���F�̃��C�g���������Ă��邩�𔻒�")]
    private RedLightCollision Player_Purple_Flag;

    [Tooltip("")]
    private bool ParticleSystem;

    [Header("White��Hp��ݒ�"), SerializeField]
    private int Purple_Enemy_Hp;

    [Tooltip("")]
    private float Enemy_Hit_Time = 1.1f;

    [Tooltip("")]
    private const float Hit_Cool_Time = 1;

    private void Start()
    {
        Red_Attack_Flag  = false;
        Blue_Attack_Flag = false;
        ParticleSystem   = false; 
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
                    Destroy(this.gameObject);
                }
            }

            if (!ParticleSystem)
            {
                ParticleSystem newParticle = Instantiate(particle);
                newParticle.transform.position = this.transform.position;
                newParticle.Play();
                ParticleSystem = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("redlight"))
        {
            Red_Attack_Flag = true;
            Player_Purple_Flag = other.gameObject.GetComponent<RedLightCollision>();
        }

        if (other.gameObject.CompareTag("bluelight"))
        {
            Blue_Attack_Flag = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("redlight"))
        {
            Red_Attack_Flag = false;
        }

        if (other.gameObject.CompareTag("bluelight"))
        {
            Blue_Attack_Flag = false;
        }
    }
}
