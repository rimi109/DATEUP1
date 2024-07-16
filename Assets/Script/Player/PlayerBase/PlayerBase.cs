using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [Header("PlayerのModelのGameObjectを取得"), SerializeField]
    private GameObject       thisGameObject;

    [Header("Playerのhpの画像を参照"), SerializeField]
    private GameObject       hpImage;

    [Tooltip("PlayerのMaxHpを設定")]
    private const int        HP_MAX = 3;

    [Tooltip("PlayerのHPが今いくつかを測る")]
    public  int              HealthCount { get; private set; }

    [Header("PlayerのHpの初期値を設定"), SerializeField]
    private int              healthInitialValue;


    [Header("Playerの回復したときの表示するEffect"), SerializeField]
    private ParticleSystem   heelEffect;

    [Tooltip("Playerの回復したときの表示するEffect")]
    private ParticleSystem   heelEffectPosition;


    [Header("Playerがダメージをくらったときに再生するAudioClipを参照"), SerializeField]
    private AudioClip        damageAudioClip;

    [Header("Playerがダメージをくらったときに再生するAudioSourceを参照"), SerializeField]
    private AudioSource      damageAudioSource;


    [Header("PlayerのAnimatorを参照"), SerializeField]
    private Animator         animator;

    [Header("PlayerManagerのScriptを参照"), SerializeField]
    private PlayerManager    manager;

    [Header("Playerが動く際に参照するプログラム"), SerializeField]
    private PlayerMove       move;

    [Header("PlayerのHpのプログラムを参照"), SerializeField]
    private Health           health;


    [Tooltip("自分が死んだかを判定する"), HideInInspector]
    public bool              deadFlag;

    private void Start()
    {
        deadFlag = false;
        HealthCount = healthInitialValue;
    }

    private void Update()
    {

        if (deadFlag)
            return;

        move.Player_Move();

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Heart"))
        {
            if (HealthCount >= HP_MAX)
            {
                Destroy(collision.gameObject);
                return;
            }
            ++HealthCount;
            health.PlayerRecoveryFunction();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDamaged();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
             var playerBase =  collision.gameObject.GetComponent<PlayerBase>();

            if (!deadFlag && playerBase.deadFlag)
            {
                playerBase.PlayerRevival();
                PlayerDamaged();
            }
        }
    }

    #region 自分が生き返った場合実行するプログラム
    /// <summary>
    /// 自分が生き返った場合実行するプログラム
    /// </summary>
    public void PlayerRevival()
    {
        ++HealthCount;

        animator.SetBool("Down", false);

        manager.ListAdd(this.transform);

        health.PlayerRecoveryFunction();

        deadFlag = false;

        heelEffectPosition = Instantiate(heelEffect);
        heelEffectPosition.transform.position = this.transform.position;
        heelEffectPosition.Play();
    }
    #endregion

    #region　Player自身がダメージをくらった時に実行するプログラム
    /// <summary>
    /// Player自身がダメージをくらった時に実行するプログラム
    /// </summary>
    public void PlayerDamaged()
    {
        if (HealthCount <= 0)
            return;

        --HealthCount;

        health.HealthFunction();

        hpImage.SetActive(true);

        damageAudioSource.PlayOneShot(damageAudioClip);
       
        if (HealthCount == 0)
        {
            PlayerDieAnimator();
        }
    }
    #endregion

    #region Playerが死んだとき実行する関数
    /// <summary>
    /// Playerが死んだとき実行する関数
    /// </summary>
    public void PlayerDieAnimator()
    {
      
        deadFlag = true;
        animator.SetBool("Down", true);
        manager.List_Remove(this.transform);
    }
    #endregion

}
