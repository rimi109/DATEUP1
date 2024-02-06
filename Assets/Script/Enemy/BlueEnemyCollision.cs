using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyCollision : MonoBehaviour
{
    [Tooltip("青色のライトが当たっているかを判定")]
    private bool Blue_Attack_Flag;

    [SerializeField]
    private ParticleSystem particle;

    [Tooltip("")]
    private ParticleSystem newParticle;

    [Tooltip("")]
    private bool ParticleSystem;

    [Tooltip("")]
    private bool Enemy_Destory_flag;

    [Header("WhiteのHpを設定"), SerializeField]
    private int Blus_Enemy_Hp;

    [Tooltip("")]
    private float Enemy_Hit_Time = 1.1f;

    [Tooltip("")]
    private const float Hit_Cool_Time = 1;

    [Tooltip("")]
    private float Enemy_Destroy_Time;

    public float shrinkSpeed = 0.5f;  // 縮小の速度
    private const float UPWADR_SPEED = 50.0f;  
    private const float ROTATION_SPEED = 4000.0f;

    [SerializeField]
    private PlayerScript Enemy_Destroy_System;

    public PlayerScript targetR;

    private void Start()
    {
        Blue_Attack_Flag = false;
        ParticleSystem = false;
        Enemy_Destory_flag = false;
        targetR = GameObject.FindObjectOfType<PlayerScript>();

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
            Debug.Log("Enemy_destroy_animation");
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

    private void Enemy_destroy_animation()
    {
        Vector3 currentScale = transform.localScale;
        float newScale = Mathf.Max(currentScale.x - shrinkSpeed, 0.0f);  // 最小のスケールを設定
        transform.localScale = new Vector3(newScale, newScale, newScale);

        Quaternion deltaRotation = Quaternion.Euler(0f, ROTATION_SPEED * Time.deltaTime, 0f);
        this.transform.rotation *= deltaRotation;
    }
}
