using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRed : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemyGenerateSystem;

    [SerializeField]
    private Wave1 GameWave1;

    [SerializeField]
    private Wave2 GameWave2;

    [SerializeField]
    private Wave3 GameWave3;

    [Header("Player��Model��GameObject���擾"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Player���g��Transform���Q��"), SerializeField]
    private Transform Player_Transform_;

    [Header("Player��MoveSpeed���Q��"), SerializeField]
    private float Player_Move_Speed_;

    [Header("Player�����l�ڂ�Player�����w��"), SerializeField]
    private int Player_Numbers_;

    [Header("Player��Rigidbody���Q��"), SerializeField]
    private Rigidbody Player_Rd_;

    [Header("Player��Animator���Q��"), SerializeField]
    private Animator PlayerAnimator;

    [Header("Player��Hp���w��"), SerializeField]
    private int Player_Hp;

    [Header("Player��hp�̉摜���Q��"), SerializeField]
    private GameObject Player_Hp_image;

    [Header("Player��Hp�̃v���O�������Q��"), SerializeField]
    private healthRed Player_health;

    [Header(""), SerializeField]
    private PlayerBlue player_Blue;

    [Header(""), SerializeField]
    private PlayerScript player_Green;

    [Header(""), SerializeField]
    private AudioClip Player_AudioClip;

    [Header(""), SerializeField]
    private AudioSource audioSource;

    public bool Player_dead_Flag;

    private void Start()
    {
        Player_dead_Flag = false;
    }

    void Update()
    {
        if (Gamepad.current == null)
            return;

        var Velocity = Player_Rd_.velocity;

        var GamepadLeftStickValue = Gamepad.all[Player_Numbers_].leftStick.ReadValue();
        var LeftStickvalue = new Vector3(GamepadLeftStickValue.x, 0, GamepadLeftStickValue.y);
        if (LeftStickvalue != Vector3.zero && Player_Hp >= 1)
        {
            Velocity = LeftStickvalue * Player_Move_Speed_;
            PlayerAnimator.SetBool("walk", true);
        }
        else
        {
            Velocity = Vector3.zero;
            PlayerAnimator.SetBool("walk", false);
        }

        Player_Rd_.velocity = Velocity;

        var GamepadrightStickValue = Gamepad.all[Player_Numbers_].rightStick.ReadValue();
        var RightStickvalue = new Vector3(GamepadrightStickValue.x, 0, GamepadrightStickValue.y);

        if (RightStickvalue != Vector3.zero && Player_Hp >= 1)
        {
            Player_Transform_.transform.localRotation = Quaternion.LookRotation(RightStickvalue);
        }
    }

    void OnCollisionEnter(Collision collision)
    {


        //���������I�u�W�F�N�g�̃^�O��"Enemy"
        if (collision.gameObject.CompareTag("EnemyW1"))
        {

            Player_health.Health_Function();
            Player_Hp_image.SetActive(true);
            audioSource.PlayOneShot(Player_AudioClip);
            Player_Hp -= 1;
        }

        //���������I�u�W�F�N�g�̃^�O��"Enemy"
        if (collision.gameObject.CompareTag("EnemyW2"))
        {
            Player_health.Health_Function();
            Player_Hp_image.SetActive(true);
            audioSource.PlayOneShot(Player_AudioClip);
            Player_Hp -= 1;
        }

        //���������I�u�W�F�N�g�̃^�O��"Enemy"
        if (collision.gameObject.CompareTag("EnemyW3"))
        {
            Player_health.Health_Function();
            Player_Hp_image.SetActive(true);
            audioSource.PlayOneShot(Player_AudioClip);
            Player_Hp -= 1;
        }


        if (collision.gameObject.CompareTag("PlayerBlue"))
        {
            if (Player_dead_Flag && Player_Hp < 0)
            {
                PlayerAnimator.SetBool("Down", false);
                Player_Hp += 1;
                Player_health.Player_Recovery_Function();
                player_Blue.PlayerBlue_Recovery_Hp();
                Player_dead_Flag = false;
            }
        }
        if (collision.gameObject.CompareTag("PlayerGreen"))
        {
            if (Player_dead_Flag && Player_Hp < 0)
            {
                PlayerAnimator.SetBool("Down", false);
                Player_Hp += 1;
                Player_health.Player_Recovery_Function();
                player_Green.PlayerGreen_Recovery_Hp();
                Player_dead_Flag = false;
            }
        }
    }
    public void Wave1EnemyDestroy()
    {
        EnemyGenerateSystem.wave1Count();
        GameWave1.CountW1();
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
        PlayerAnimator.SetBool("Down", true);
        Player_dead_Flag = true;
    }

    public void PlayerRed_Recovery_Hp()
    {
        Player_Hp -= 1;
        Player_health.Health_Function();
    }
}
