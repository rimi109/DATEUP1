using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRed : MonoBehaviour
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

    [Header("PlayerのMoveSpeedを参照"), SerializeField]
    private float Player_Move_Speed_;

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

    [Header("PlayerのHpのプログラムを参照"), SerializeField]
    private healthRed Player_health;

    [Header(""), SerializeField]
    private PlayerBlue player_Blue;

    [Header(""), SerializeField]
    private PlayerScript player_Green;

    [Header(""), SerializeField]
    private AudioClip Player_AudioClip;

    [Header(""), SerializeField]
    private AudioSource audioSource;

    [Header("Playerの回復したときの表示するEffect"), SerializeField]
    private ParticleSystem Player_Heel_Effect;

    [Tooltip("Playerの回復したときの表示するEffect")]
    private ParticleSystem Player_Heel_Effect1;

    public bool Player_Red_dead_Flag;

    public bool Player_Red_revival_Flag { get; private set; }

    private void Start()
    {
        Player_Red_dead_Flag = false;
        Player_Red_revival_Flag = false;
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


        //当たったオブジェクトのタグが"Enemy"
        if (collision.gameObject.CompareTag("EnemyW1"))
        {

            Player_health.Health_Function();
            Player_Hp_image.SetActive(true);
            audioSource.PlayOneShot(Player_AudioClip);
            Player_Hp -= 1;
        }

        //当たったオブジェクトのタグが"Enemy"
        if (collision.gameObject.CompareTag("EnemyW2"))
        {
            Player_health.Health_Function();
            Player_Hp_image.SetActive(true);
            audioSource.PlayOneShot(Player_AudioClip);
            Player_Hp -= 1;
        }

        //当たったオブジェクトのタグが"Enemy"
        if (collision.gameObject.CompareTag("EnemyW3"))
        {
            Player_health.Health_Function();
            Player_Hp_image.SetActive(true);
            audioSource.PlayOneShot(Player_AudioClip);
            Player_Hp -= 1;
        }


        if (collision.gameObject.CompareTag("PlayerBlue"))
        {
            if (Player_Red_dead_Flag && Player_Hp <= 0)
            {
                PlayerAnimator.SetBool("Down", false);
                Player_Hp += 1;
                Player_health.Player_Recovery_Function();
                player_Blue.PlayerBlueRecoveryHp();
                Player_Red_dead_Flag = false;
                Player_Red_revival_Flag = true;
                Player_Heel_Effect1 = Instantiate(Player_Heel_Effect);
                Player_Heel_Effect1.transform.position = this.transform.position;
                Player_Heel_Effect1.Play();
            }
        }
        if (collision.gameObject.CompareTag("PlayerGreen"))
        {
            if (Player_Red_dead_Flag && Player_Hp <= 0)
            {
                player_Green.PlayerGreenRecoveryHp();
                PlayerRedRevival();
            }
        }
    }

    #region 自分が生き返った場合実行するプログラム
    /// <summary>
    /// 自分が生き返った場合実行するプログラム
    /// </summary>
    private void PlayerRedRevival()
    {
        PlayerAnimator.SetBool("Down", false);
        Player_Hp += 1;
        Player_health.Player_Recovery_Function();

        Player_Red_dead_Flag = false;
        Player_Red_revival_Flag = true;
        Player_Heel_Effect1 = Instantiate(Player_Heel_Effect);
        Player_Heel_Effect1.transform.position = this.transform.position;
        Player_Heel_Effect1.Play();
    }
    #endregion

    #region　Player自身がダメージをくらった時に実行するプログラム
    /// <summary>
    /// Player自身がダメージをくらった時に実行するプログラム
    /// </summary>
    private void PlayerDamaged()
    {
 
    }
    #endregion

    public void PlayerDieAnimator()
    {
        PlayerAnimator.SetBool("Down", true);
        Player_Red_dead_Flag = true;
    }

    public void PlayerRedRecoveryHp()
    {
        Player_Hp -= 1;
        Player_health.Health_Function();
    }
}
