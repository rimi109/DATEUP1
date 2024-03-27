using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Player��Model��GameObject���擾"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Player��hp�̉摜���Q��"), SerializeField]
    private GameObject Player_Hp_image;


    [Header("Player���g��Transform���Q��"), SerializeField]
    private Transform Player_Transform;


    [Header("Player��MoveSpeed���Q��"), SerializeField]
    private float Player_Move_Speed;


    [Header("Player�����l�ڂ�Player�����w��"), SerializeField]
    private int Player_Numbers;

    [Header("Player��Hp���w��"), SerializeField]
    private int Player_Hp;

    [Tooltip("Player��MaxHp��ݒ�")]
    private const int PLAYER_HP_MAX = 3;

    [Header("Player��Rigidbody���Q��"), SerializeField]
    private Rigidbody Player_Rd;


    [Header("Player��Animator���Q��"), SerializeField]
    private Animator Player_Animator;


    [Header("Player�̉񕜂����Ƃ��̕\������Effect"), SerializeField]
    private ParticleSystem Player_Heel_Effect;

    [Tooltip("Player�̉񕜂����Ƃ��̕\������Effect")]
    private ParticleSystem Player_Heel_Effect1;


    [Header("Player���_���[�W����������Ƃ��ɍĐ�����AudioClip���Q��"), SerializeField]
    private AudioClip Player_Damage_AudioClip;

    [Header("Player���_���[�W����������Ƃ��ɍĐ�����AudioSource���Q��"), SerializeField]
    private AudioSource Player_Damage_Audio_Source;


    [Header("�G��wave1��Script���擾"), SerializeField]
    private Wave1 Game_Wave_1;

    [Header("�G��wave2��Script���擾"), SerializeField]
    private Wave2 GameWave2;

    [Header("�G��wave3��Script���擾"), SerializeField]
    private Wave3 GameWave3;

    [Header("PlayerManager��Script���Q��"), SerializeField]
    private PlayerManager Player_Manager;

    [Header("EnemyGenerateSystem��Script���Q��"), SerializeField]
    private EnemyGenerate EnemyGenerateSystem;

    [Header("Player��Hp�̃v���O�������Q��"), SerializeField]
    private health Player_health;

    [Tooltip("���������񂾂��𔻒肷��")]
    public bool Player_Green_Dead_Flag;

    [Tooltip("�����������Ԃ������𔻒�")]
    public bool Player_Green_revival_Flag { get; private set; }

    private void Start()
    {
        Player_Green_Dead_Flag = false;
        Player_Green_revival_Flag = false;
    }

    void Update()
    {
        if (Gamepad.current == null)
            return;

        Player_Move();

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
    }

    #region�@Player���g���_���[�W������������Ɏ��s����v���O����
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

    #region�@Player�������ۂɎ��s����v���O����
    /// <summary>
    /// Player�������ۂɎ��s����v���O����
    /// </summary>
    private void Player_Move()
    {
        var Velocity = Player_Rd.velocity;
        var GamepadLeftStickValue = Gamepad.all[Player_Numbers].leftStick.ReadValue();
        var LeftStickvalue = new Vector3(GamepadLeftStickValue.x, 0, GamepadLeftStickValue.y);
        if (LeftStickvalue != Vector3.zero && Player_Hp > 0)
        {
            Velocity = LeftStickvalue * Player_Move_Speed;
            Player_Animator.SetBool("walk", true);
        }
        else
        {
            Velocity = Vector3.zero;
            Player_Animator.SetBool("walk", false);
        }

        Player_Rd.velocity = Velocity;

        var GamepadrightStickValue = Gamepad.all[Player_Numbers].rightStick.ReadValue();
        var RightStickvalue = new Vector3(GamepadrightStickValue.x, 0, GamepadrightStickValue.y);

        if (RightStickvalue != Vector3.zero && Player_Hp > 0)
        {
            Player_Transform.transform.localRotation = Quaternion.LookRotation(RightStickvalue);
        }
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
}
