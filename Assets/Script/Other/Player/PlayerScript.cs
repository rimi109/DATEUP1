using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Player��Model��GameObject���擾"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Player��hp�̉摜���Q��"), SerializeField]
    private GameObject Player_Hp_image;

    [Header("Player��Hp���w��"), SerializeField]
    private int Player_Hp;

    [Tooltip("Player��MaxHp��ݒ�")]
    private const int PLAYER_HP_MAX = 3;

    [Header("Player�̉񕜂����Ƃ��̕\������Effect"), SerializeField]
    private ParticleSystem Player_Heel_Effect;

    [Tooltip("Player�̉񕜂����Ƃ��̕\������Effect")]
    private ParticleSystem Player_Heel_Effect1;


    [Header("Player���_���[�W����������Ƃ��ɍĐ�����AudioClip���Q��"), SerializeField]
    private AudioClip Player_Damage_AudioClip;

    [Header("Player���_���[�W����������Ƃ��ɍĐ�����AudioSource���Q��"), SerializeField]
    private AudioSource Player_Damage_Audio_Source;

    [Header("Player��Animator���Q��"), SerializeField]
    private Animator Player_Animator;

    [Header("�G��wave1��Script���擾"), SerializeField]
    private Wave1 Game_Wave_1;

    [Header("�G��wave2��Script���擾"), SerializeField]
    private Wave2 GameWave2;

    [Header("�G��wave3��Script���擾"), SerializeField]
    private Wave3 GameWave3;

    [Header("PlayerRed��Script���Q��"), SerializeField]
    private PlayerRed Player_Red;

    [Header("PlayerBlue��Script���Q��"), SerializeField]
    private PlayerBlue Player_Blue;

    [Header("PlayerManager��Script���Q��"), SerializeField]
    private PlayerManager Player_Manager;

    [Header("EnemyGenerateSystem��Script���Q��"),SerializeField]
    private EnemyGenerate EnemyGenerateSystem;

    [Header("Player��Hp�̃v���O�������Q��"), SerializeField]
    private health Player_health;

    [Tooltip("���������񂾂��𔻒肷��")]
    public bool Player_Green_Dead_Flag;

    [Tooltip("�����������Ԃ������𔻒�")]
    public bool Player_Green_revival_Flag { get; private set; }

    private void Start()
    {
        Player_Green_Dead_Flag �@ = false;
        Player_Green_revival_Flag = false;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Heart"))
        {
            if (Player_Hp >= PLAYER_HP_MAX)
            {
                Destroy(collision.gameObject);
                return;
            }
            ++Player_Hp;
            Player_health.Player_Recovery_Function();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyW1"))
        {
            Player_Damaged();
        }

        if (collision.gameObject.CompareTag("EnemyW2"))
        {
            Player_Damaged();
        }

        if (collision.gameObject.CompareTag("EnemyW3"))
        {
            Player_Damaged();
        }

        if (collision.gameObject.CompareTag("PlayerBlue"))
        {
            if (Player_Green_Dead_Flag && Player_Hp <= 0)
            {
                Player_Blue.PlayerBlue_Recovery_Hp();
                Player_Green_Revival();
            }
        }

        if (collision.gameObject.CompareTag("PlayerRed"))
        {
            if (Player_Green_Dead_Flag && Player_Hp <= 0)
            {
                Player_Red.PlayerRed_Recovery_Hp();
                Player_Green_Revival();
            }
        }
    }

    #region �����������Ԃ����ꍇ���s����v���O����
    /// <summary>
    /// �����������Ԃ����ꍇ���s����v���O����
    /// </summary>
    private void Player_Green_Revival()
    {
        ++Player_Hp;

        Player_Animator.SetBool("Down", false);

        Player_Manager.List_Add(this.transform);

        Player_health.Player_Recovery_Function();

        Player_Green_Dead_Flag    = false;

        Player_Green_revival_Flag = true;

        Player_Heel_Effect1 = Instantiate(Player_Heel_Effect);
        Player_Heel_Effect1.transform.position = this.transform.position;
        Player_Heel_Effect1.Play();
    }
    #endregion

�@�@#region�@Player���g���_���[�W������������Ɏ��s����v���O����
    /// <summary>
    /// Player���g���_���[�W������������Ɏ��s����v���O����
    /// </summary>
    private void Player_Damaged()
    {
        Player_health.Health_Function();
        Player_Hp_image.SetActive(true);
        Player_Damage_Audio_Source.PlayOneShot(Player_Damage_AudioClip);
        --Player_Hp;
    }
    #endregion

    public void Wave1EnemyDestroy()
    {
        EnemyGenerateSystem.wave1Count();
        Game_Wave_1.CountW1();
    }

    public void Wave2EnemyDestroy()
    {
        EnemyGenerateSystem.wave3Count();
        GameWave2.CountW2();
    }

    public void Wave3EnemyDestroy()
    {
        EnemyGenerateSystem.wave3Count();
        GameWave3.CountW3();
    }

    public void PlayerDieAnimator()
    {
        Player_Animator.SetBool("Down", true);
        Player_Green_Dead_Flag = true;
        Player_Manager.List_Remove(this.transform);
    }

    public void PlayerGreen_Recovery_Hp()
    {
        Player_Hp -= 1;
        Player_health.Health_Function();
    }
}

