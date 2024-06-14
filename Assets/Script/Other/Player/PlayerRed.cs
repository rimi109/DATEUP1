using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRed : MonoBehaviour
{
    [Header("EnemyGenerateSystemのScriptを参照"), SerializeField]
    private EnemyGenerate Enemy_Generate_System;

    [Header("PlayerのModelのGameObjectを取得"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Playerのhpの画像を参照"), SerializeField]
    private GameObject Player_Hp_image;


    [Header("Player自身のTransformを参照"), SerializeField]
    private Transform Player_Transform_;


    [Header("PlayerのMoveSpeedを参照"), SerializeField]
    private float Player_Move_Speed_;


    [Header("Playerが何人目のPlayerかを指定"), SerializeField]
    private int Player_Numbers_;

    [Header("PlayerのHpを指定"), SerializeField]
    private int Player_Hp;

    [Tooltip("PlayerのMaxHpを設定")]
    private const int PLAYER_HP_MAX = 3;


    [Header("PlayerのRigidbodyを参照"), SerializeField]
    private Rigidbody Player_Rd_;

    [Header("PlayerのAnimatorを参照"), SerializeField]
    private Animator PlayerAnimator;


    [Header("PlayerのHpのプログラムを参照"), SerializeField]
    private healthRed Player_Health;


    [Header("PlayerRedのScriptを参照"), SerializeField]
    private PlayerBlue Player_Blue;


    [Header("PlayerBlueのScriptを参照"), SerializeField]
    private PlayerScript Player_Green;

    [Header("PlayerManagerのScriptを参照"), SerializeField]
    private PlayerManager Player_Manager;


    [Header("Playerがダメージをくらったときに再生するAudioClipを参照"), SerializeField]
    private AudioClip Player_Damage_AudioClip;

    [Header("Playerがダメージをくらったときに再生するAudioSourceを参照"), SerializeField]
    private AudioSource Player_Damage_Audio_Source;


    [Header("Playerの回復したときの表示するEffect"), SerializeField]
    private ParticleSystem Player_Heel_Effect;

    [Tooltip("Playerの回復したときの表示するEffect")]
    private ParticleSystem Player_Heel_Effect_Position;


    [Header("Playerが動く際に参照するプログラム"), SerializeField]
    private PlayerMove Player_Move;


    [Tooltip("自分が死んだかを判定する"),HideInInspector]
    public bool Player_Red_Dead_Flag;

    [Tooltip("自分が生き返ったどうかを判定"),HideInInspector]
    public bool Player_Red_Revival_Flag { get; private set; }

    private void Start()
    {
        Player_Red_Dead_Flag = false;
        Player_Red_Revival_Flag = false;
    }

    private void Update()
    {
        if (Player_Red_Dead_Flag)
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
            Player_Health.Player_Recovery_Function();
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

        if (collision.gameObject.CompareTag("PlayerBlue"))
        {
            if (Player_Red_Dead_Flag && Player_Hp <= 0)
            {
                Player_Blue.PlayerBlueRecoveryHp();
                PlayerRevival();
            }
        }
        if (collision.gameObject.CompareTag("PlayerGreen"))
        {
            if (Player_Red_Dead_Flag && Player_Hp <= 0)
            {
                Player_Green.Player_Green_Recovery_Hp();
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

        Player_Red_Dead_Flag = false;

        Player_Red_Revival_Flag = true;

        PlayerAnimator.SetBool("Down", false);

        Player_Health.Player_Recovery_Function();

      
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
        Player_Health.Health_Function();
        Player_Hp_image.SetActive(true);
        Player_Damage_Audio_Source.PlayOneShot(Player_Damage_AudioClip);
        --Player_Hp;
    }
    #endregion

    /// <summary>
    /// Playerが死んだとき実行する関数
    /// </summary>
    public void PlayerDieAnimator()
    {
        PlayerAnimator.SetBool("Down", true);
        Player_Red_Dead_Flag = true;
        Player_Manager.List_Remove(this.transform);
    }

    /// <summary>
    /// Playerが生き返ったときに実行する関数
    /// </summary>
    public void PlayerRedRecoveryHp()
    {
       
        Player_Health.Health_Function();
        --Player_Hp;
    }
}
