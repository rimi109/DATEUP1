using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlue : MonoBehaviour
{
    [Header("EnemyGenerateSystemのScriptを参照"), SerializeField]
    private EnemyGenerate Enemy_Generate_System;

    [Header("PlayerのModelのGameObjectを取得"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Player自身のTransformを参照"), SerializeField]
    private Transform Player_Transform_;

    [Header("PlayerのHpを指定"), SerializeField]
    private int Player_Hp;

    [Header("Playerが何人目のPlayerかを指定"), SerializeField]
    private int Player_Numbers_;

    [Tooltip("PlayerのMaxHpを設定")]
    private const int PLAYER_HP_MAX = 3;

    [Header("PlayerのRigidbodyを参照"), SerializeField]
    private Rigidbody Player_Rd_;

    [Header("PlayerのAnimatorを参照"), SerializeField]
    private Animator PlayerAnimator;

    [Header("Playerのhpの画像を参照"), SerializeField]
    private GameObject Player_Hp_image;

    [Header(""), SerializeField]
    private PlayerRed Player_Red;

    [Header(""), SerializeField]
    private PlayerScript Player_Green;

    [Header("PlayerのHpのプログラムを参照"), SerializeField]
    private healthBlue Player_health;

    [Header(""), SerializeField]
    private AudioClip Player_AudioClip;

    [Header(""), SerializeField]
    private AudioSource Audio_Source;

    [Header("Playerの回復したときの表示するEffect"), SerializeField]
    private ParticleSystem Player_Heel_Effect;

    [Tooltip("Playerの回復したときの表示するEffect")]
    private ParticleSystem Player_Heel_Effect_Position;

    [Header("Playerが動く際に参照するプログラム"), SerializeField]
    private PlayerMove Player_Move;

    [Header("PlayerManagerのScriptを参照"), SerializeField]
    private PlayerManager Player_Manager;

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
            PlayerDamaged();
        }


        if (collision.gameObject.CompareTag("EnemyW2"))
        {
            PlayerDamaged();
        }


        if (collision.gameObject.CompareTag("EnemyW3"))
        {
            PlayerDamaged();
        }

        if (collision.gameObject.CompareTag("PlayerGreen"))
        {
            if (Player_Blue_Dead_Flag && Player_Hp <= 0)
            {
                Player_Green.Player_Green_Recovery_Hp();
                PlayerRevival();
            }
        }

        if (collision.gameObject.CompareTag("PlayerRed"))
        {
            if (Player_Blue_Dead_Flag && Player_Hp <= 0)
            {
                Player_Red.PlayerRedRecoveryHp();

                PlayerRevival();
            }
        }
    }

    #region 自分が生き返った場合実行するプログラム
    /// <summary>
    /// 自分が生き返った場合実行するプログラム
    /// </summary>
    private void PlayerRevival()
    {

        ++Player_Hp;

        Player_Manager.ListAdd(this.transform);

        PlayerAnimator.SetBool("Down", false);
      
        Player_health.Player_Recovery_Function();

        Player_Blue_Dead_Flag = false;

        Player_Blue_revival_Flag = true;

        Player_Heel_Effect_Position = Instantiate(Player_Heel_Effect);
        Player_Heel_Effect_Position.transform.position = this.transform.position;
        Player_Heel_Effect_Position.Play();
    }
    #endregion

    #region　Player自身がダメージをくらった時に実行するプログラム
    /// <summary>
    /// Player自身がダメージをくらった時に実行するプログラム
    /// </summary>
    private void PlayerDamaged()
    {
        Player_health.Health_Function();
        Player_Hp_image.SetActive(true);
        Audio_Source.PlayOneShot(Player_AudioClip);
        --Player_Hp;
    }
    #endregion


    public void PlayerDieAnimator()
    {
        PlayerAnimator.SetBool("Down", true);
        Player_Blue_Dead_Flag = true;
        Player_Manager.List_Remove(this.transform);
    }

    public void PlayerBlueRecoveryHp()
    {
        --Player_Hp;
        Player_health.Health_Function();
    }
}
