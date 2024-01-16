using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyCollisionW2 : MonoBehaviour
{
    [Tooltip("ÂF‚Ìƒ‰ƒCƒg‚ª“–‚½‚Á‚Ä‚¢‚é‚©‚ğ”»’è")]
    private bool Blue_Attack_Flag;

    [SerializeField]
    private ParticleSystem particle;

    [Tooltip("")]
    private ParticleSystem newParticle;

    [Tooltip("")]
    private bool ParticleSystem;

    [Header("White‚ÌHp‚ğİ’è"), SerializeField]
    private int Purple_Enemy_Hp;

    [Tooltip("")]
    private float Enemy_Hit_Time = 1.1f;

    [Tooltip("")]
    private const float Hit_Cool_Time = 1;

    [SerializeField]
    private PlayerScript Enemy_Destroy_System;

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
                Purple_Enemy_Hp -= 2;
                Debug.Log(Purple_Enemy_Hp);
                Enemy_Hit_Time = 0;
                if (Purple_Enemy_Hp <= 0)
                {
                    Destroy(this.gameObject);
                    Destroy(newParticle);
                    targetR.Wave2EnemyDestroy();
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
