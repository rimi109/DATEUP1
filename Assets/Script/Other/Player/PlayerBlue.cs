using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlue : MonoBehaviour
{
    [Header("EnemyGenerateSystemのScriptを参照"), SerializeField]
    private EnemyGenerate Enemy_Generate_System;


    [Header("敵のwave1のScriptを取得"), SerializeField]
    private Wave1 Game_Wave_1;

    [Header("敵のwave2のScriptを取得"), SerializeField]
    private Wave2 Game_Wave2;

    [Header("敵のwave3のScriptを取得"), SerializeField]
    private Wave3 Game_Wave3;


    [Header("PlayerのModelのGameObjectを取得"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Player自身のTransformを参照"), SerializeField]
    private Transform Player_Transform_;

    [Header("Playerが何人目のPlayerかを指定"), SerializeField]
    private int Player_Numbers_;

    [Header("PlayerのRigidbodyを参照"), SerializeField]
    private Rigidbody Player_Rd_;

    [Header("PlayerのAnimatorを参照"), SerializeField]
    private Animator PlayerAnimator;

    [Header("PlayerのHpを指定"), SerializeField]
    private int Player_Hp;

    [Header("Playerのhpの画像を参照"), SerializeField]
    private GameObject Player_Hp_image;

    [Header(""), SerializeField]
    private PlayerRed player_Red;

    [Header(""), SerializeField]
    private PlayerScript player_Green;

    [Header("PlayerのHpのプログラムを参照"), SerializeField]
    private healthBlue Player_health;

    [Header(""), SerializeField]
    private AudioClip Player_AudioClip;

    [Header(""), SerializeField]
    private AudioSource audioSource;

    [Header("Playerの回復したときの表示するEffect"), SerializeField]
    private ParticleSystem Player_Heel_Effect;

    [Tooltip("Playerの回復したときの表示するEffect")]
    private ParticleSystem Player_Heel_Effect1;

    [Header("Playerが動く際に参照するプログラム"), SerializeField]
    private PlayerMove Player_Move;

    [Tooltip("自分が死んだかを判定する"), HideInInspector]
    public bool Player_Blue_Dead_Flag;

    [Tooltip("自分が生き返ったどうかを判定"), HideInInspector]
    public bool Player_Blue_revival_Flag { get; private set; }

    private void Start()
    {
        Player_Blue_Dead_Flag = false;
        Player_Blue_revival_Flag = false;
    }

    private void Update()
    {
        if (Player_Blue_Dead_Flag)
            return;
        Player_Move.Player_Move();
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Heart"))
        {
            if (Player_Hp >= 3)
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
            Player_health.Health_Function();
            Player_Hp_image.SetActive(true);
            audioSource.PlayOneShot(Player_AudioClip);
            Player_Hp -= 1;
        }


        if (collision.gameObject.CompareTag("EnemyW2"))
        {
            Player_health.Health_Function();
            Player_Hp_image.SetActive(true);
            audioSource.PlayOneShot(Player_AudioClip);
            Player_Hp -= 1;
        }


        if (collision.gameObject.CompareTag("EnemyW3"))
        {
            Player_health.Health_Function();
            Player_Hp_image.SetActive(true);
            audioSource.PlayOneShot(Player_AudioClip);
            Player_Hp -= 1;
        }

        if (collision.gameObject.CompareTag("PlayerGreen"))
        {
            if (Player_Blue_Dead_Flag && Player_Hp <= 0)
            {
                PlayerAnimator.SetBool("Down", false);
                Player_Hp += 1;
                Player_health.Player_Recovery_Function();
                player_Green.PlayerGreenRecoveryHp();
                Player_Blue_Dead_Flag = false;
                Player_Blue_revival_Flag = true;
                Player_Heel_Effect1 = Instantiate(Player_Heel_Effect);
                Player_Heel_Effect1.transform.position = this.transform.position;
                Player_Heel_Effect1.Play();
            }
        }

        if (collision.gameObject.CompareTag("PlayerRed"))
        {
            if (Player_Blue_Dead_Flag && Player_Hp <= 0)
            {
                PlayerAnimator.SetBool("Down", false);
                Player_Hp += 1;
                Player_health.Player_Recovery_Function();
                player_Red.PlayerRedRecoveryHp();
                Player_Blue_Dead_Flag = false;
                Player_Blue_revival_Flag = true;
                Player_Heel_Effect1 = Instantiate(Player_Heel_Effect);
                Player_Heel_Effect1.transform.position = this.transform.position;
                Player_Heel_Effect1.Play();
            }
        }
    }

    public void PlayerDieAnimator()
    {
        PlayerAnimator.SetBool("Down", true);
        Player_Blue_Dead_Flag = true;
    }

    public void PlayerBlueRecoveryHp()
    {
        Player_Hp -= 1;
        Player_health.Health_Function();
    }
}
