using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyCollisionW2 : MonoBehaviour
{

    [Tooltip("赤色のライトが当たっているかを判定")]
    private bool Red_Attack_Flag;

    [SerializeField]
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

    public PlayerScript targetR;

    [Tooltip("自分が死んだかどうかを判定検知する")]
    private bool Enemy_Destory_flag;

    [Tooltip("")]
    private float Enemy_Destroy_Time;

    public float Shrink_Speed = 0.5f;
    private const float ROTATION_SPEED = 4000.0f;

    private void Start()
    {
        Red_Attack_Flag = false;
        ParticleSystem = false;

        targetR = GameObject.FindObjectOfType<PlayerScript>();
    }

    void Update()
    {
        if (Red_Attack_Flag)
        {
            Enemy_Hit_Time += Time.deltaTime;
            
            if (Enemy_Hit_Time > Hit_Cool_Time)
            {
                Purple_Enemy_Hp -= 1;
                Enemy_Hit_Time = 0;
                if (Purple_Enemy_Hp <= 0)
                {
                    Enemy_Destory_flag = true;
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
