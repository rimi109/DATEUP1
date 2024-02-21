using UnityEngine;

public class BlueEnemyCollision : MonoBehaviour
{
    [Tooltip("�F�̃��C�g���������Ă��邩�𔻒�")]
    private bool Blue_Attack_Flag;

    [Tooltip("Particle���Đ����邩�ǂ��������m����")]
    private bool Particle_System;

    [Tooltip("���������񂾂��ǂ����𔻒茟�m����")]
    private bool Enemy_Destory_flag;

    [Header("White��Hp��ݒ�"), SerializeField]
    private int Blus_Enemy_Hp;

    [Tooltip("Enemy����b���ƂɃ_���[�W��")]
    private float Enemy_Hit_Time = 1.0f;

    [Tooltip("Enemy���A���Ń_���[�W����Ȃ��悤�Ƀ��L���X�g�^�C����ݒ�")]
    private const float Hit_Cool_Time = 1;

    [Tooltip("")]
    private float Enemy_Destroy_Time;

    public float Shrink_Speed = 0.5f;
    private const float ROTATION_SPEED = 4000.0f;

    [Header("Enemy���g�ŋN����Paticle���擾"), SerializeField]
    private ParticleSystem Enemy_Particle;

    [Tooltip("Enemy���g�ŋN����Paticle���擾")]
    private ParticleSystem Enemy_Formation;

    public PlayerScript TargetR;

    private void Start()
    {
        Blue_Attack_Flag = false;
        Particle_System = false;
        Enemy_Destory_flag = false;
        TargetR = GameObject.FindObjectOfType<PlayerScript>();

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
                    TargetR.Wave1EnemyDestroy();
                }
            }

            if (!Particle_System)
            {
                Enemy_Formation = Instantiate(Enemy_Particle);
                Enemy_Formation.Play();
                Particle_System = true;
            }
            else
            {
                Enemy_Formation.transform.position = this.transform.position;
            }
        }

        if (Enemy_Destory_flag)
        {
            Enemy_destroy_animation();
            Enemy_Destroy_Time += Time.deltaTime;
            if (Enemy_Destroy_Time > 1)
            {
                Destroy(Enemy_Formation);
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
            Particle_System = false;
            Destroy(Enemy_Formation);
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
