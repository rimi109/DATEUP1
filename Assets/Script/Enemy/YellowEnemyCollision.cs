using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemyCollision : MonoBehaviour
{
    [Tooltip("緑のライトが当たっているかを判定")]
    private bool Green_Attack_Flag;

    [Tooltip("赤色のライトが当たっているかを判定")]
    private bool red_Attack_Flag;

    [Tooltip("緑色のライトが当たっているかを判定")]
    private GreenLightCollision Player_Green_Flag;

    [Header(""),SerializeField]
    private ParticleSystem particle;

    [Tooltip("")]
    private ParticleSystem newParticle;

    [Tooltip("")]
    private bool ParticleSystem;

    [Header("WhiteのHpを設定"), SerializeField]
    private int Purple_Enemy_Hp;

    [Tooltip("")]
    private float Enemy_Hit_Time = 1.1f;

    [Tooltip("")]
    private const float Hit_Cool_Time = 1;

    private void Start()
    {
        Green_Attack_Flag = false;
        red_Attack_Flag = false;
        ParticleSystem = false;
    }

    void Update()
    {
        if (red_Attack_Flag && Green_Attack_Flag && Player_Green_Flag.Yellow_Attack_Flag)
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
                    Destroy(newParticle);
                }
            }

            if (!ParticleSystem)
            {
                newParticle = Instantiate(particle);
                newParticle.transform.position = this.transform.position;
                newParticle.Play();
                ParticleSystem = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("greenlight"))
        {
            Green_Attack_Flag = true;
            Player_Green_Flag = other.gameObject.GetComponent<GreenLightCollision>();
        }

        if (other.gameObject.CompareTag("redlight"))
        {
            red_Attack_Flag = true;
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

        if (other.gameObject.CompareTag("redlight"))
        {
            red_Attack_Flag = false;
            ParticleSystem = false;
            Destroy(newParticle);
        }
    }
}
