using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [Header("PlayerのModelのGameObjectを取得"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Playerのhpの画像を参照"), SerializeField]
    private GameObject Player_Hp_Image;

    [Tooltip("PlayerのMaxHpを設定")]
    private const int PLAYER_HP_MAX = 3;

    [Tooltip(""),SerializeField]
    public int Player_Health_Count { get; private set; }


    [Header("Playerの回復したときの表示するEffect"), SerializeField]
    private ParticleSystem Player_Heel_Effect;

    [Tooltip("Playerの回復したときの表示するEffect")]
    private ParticleSystem Player_Heel_Effect_Position;


    [Header("Playerがダメージをくらったときに再生するAudioClipを参照"), SerializeField]
    private AudioClip Player_Damage_AudioClip;

    [Header("Playerがダメージをくらったときに再生するAudioSourceを参照"), SerializeField]
    private AudioSource Player_Damage_Audio_Source;


    [Header("PlayerのAnimatorを参照"), SerializeField]
    private Animator Player_Animator;

    [Header("PlayerManagerのScriptを参照"), SerializeField]
    private PlayerManager Player_Manager;

    [Header("Playerが動く際に参照するプログラム"), SerializeField]
    private PlayerMove Player_Move;

    [Header("PlayerのHpのプログラムを参照"), SerializeField]
    private Health Player_Health;

    [Tooltip("自分が死んだかを判定する"), HideInInspector]
    public bool Player_Dead_Flag;



    private void Start()
    {
        Player_Dead_Flag = false;
    }

    private void Update()
    {
        if (Player_Dead_Flag)
            return;
        Player_Move.Player_Move();
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Heart"))
        {
            if (Player_Health_Count >= PLAYER_HP_MAX)
            {
                Destroy(collision.gameObject);
                return;
            }
            ++Player_Health_Count;
            Player_Health.Player_Recovery_Function();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Player_Damaged();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
             var playerBase =  collision.gameObject.GetComponent<PlayerBase>();

            if (Player_Dead_Flag && Player_Health_Count <= 0)
            {
                Player_Dead_Flag = false;
                Player_Revival();
            }

            if (playerBase.Player_Dead_Flag)
            {
                Player_Damaged();
            }
        }
    }

    #region 自分が生き返った場合実行するプログラム
    /// <summary>
    /// 自分が生き返った場合実行するプログラム
    /// </summary>
    public void Player_Revival()
    {
        ++Player_Health_Count;

        Player_Animator.SetBool("Down", false);

        Player_Manager.ListAdd(this.transform);

        Player_Health.Player_Recovery_Function();

        Player_Dead_Flag = false;

        Player_Heel_Effect_Position = Instantiate(Player_Heel_Effect);
        Player_Heel_Effect_Position.transform.position = this.transform.position;
        Player_Heel_Effect_Position.Play();
    }
    #endregion

    #region　Player自身がダメージをくらった時に実行するプログラム
    /// <summary>
    /// Player自身がダメージをくらった時に実行するプログラム
    /// </summary>
    private void Player_Damaged()
    {
        if (Player_Health_Count <= 0)
            return;
        --Player_Health_Count;
        Player_Health.Health_Function();
        Player_Hp_Image.SetActive(true);
        Player_Damage_Audio_Source.PlayOneShot(Player_Damage_AudioClip);
       
        if (Player_Health_Count == 0)
        {
            Player_Die_Animator();
        }
    }
    #endregion

    /// <summary>
    /// Playerが死んだとき実行する関数
    /// </summary>
    public void Player_Die_Animator()
    {
        Player_Animator.SetBool("Down", true);
        Player_Dead_Flag = true;
        Player_Manager.List_Remove(this.transform);
    }
}
