using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyCollisionW2 : MonoBehaviour
{
    [Tooltip("青色のライトが当たっているかを判定")]
    private bool Blue_Attack_Flag;

    [SerializeField]
    private ParticleSystem particle;

    [Tooltip("")]
    private ParticleSystem newParticle;

    [Tooltip("")]
    private bool ParticleSystem;

    [Header("WhiteのHpを設定"), SerializeField]
    private int Blue_Enemy_Hp;

    [Tooltip("")]
    private float Enemy_Hit_Time = 1.1f;

    [Tooltip("")]
    private const float Hit_Cool_Time = 1;

    public PlayerScript targetR;

    private void Start()
    {
        Blue_Attack_Flag = false;
        ParticleSystem = false;

        targetR = GameObject.FindObjectOfType<PlayerScript>();

    }

    void Update()
    {
        if (Blue_Attack_Flag)
        {
            Enemy_Hit_Time += Time.deltaTime;

            if (Enemy_Hit_Time > Hit_Cool_Time)
            {
                Blue_Enemy_Hp -= 2;
                Debug.Log(Blue_Enemy_Hp);
                Enemy_Hit_Time = 0;
                if (Blue_Enemy_Hp <= 0)
                {

                    Destroy(newParticle);
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
            Blue_Attack_Flag = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("bluelight"))
        {
            Blue_Attack_Flag = false;
            ParticleSystem = false;
            Destroy(newParticle);
        }
    }
}
