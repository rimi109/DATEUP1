using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemyGenerateSystem;

    [SerializeField]
    private Wave1 GameWave1;

    [SerializeField]
    private Wave2 GameWave2;

    [SerializeField]
    private Wave3 GameWave3;
    
    [Header("PlayerのModelのGameObjectを取得"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Playerのhpの画像を参照"), SerializeField]
    private GameObject Player_Hp_image;

    [Header("Player自身のTransformを参照"),SerializeField]
    private Transform Player_Transform_;

    [Header("PlayerのMoveSpeedを参照"), SerializeField]
    private float Player_Move_Speed_;

    [Header("Playerが何人目のPlayerかを指定"), SerializeField]
    private int Player_Numbers_;

    [Header("PlayerのHpを指定"), SerializeField]
    private int Player_Hp;

    [Header("PlayerのRigidbodyを参照"), SerializeField]
    private Rigidbody Player_Rd_;

    [Header("PlayerのAnimatorを参照"), SerializeField]
    private Animator PlayerAnimator;

    [Header("PlayerのHpのプログラムを参照"),SerializeField]
    private health Player_health;

    [Header(""), SerializeField]
    private PlayerRed player_Red;

    [Header(""), SerializeField]
    private PlayerBlue player_Blue;

    [Header(""), SerializeField]
    private AudioClip Player_AudioClip;

    [Header(""),SerializeField]
    private  AudioSource audioSource;

    public bool Player_dead_Flag;

    [Header("Playerの回復したときの表示するEffect"),SerializeField]
    private ParticleSystem Player_Heel_Effect;

    [Tooltip("Playerの回復したときの表示するEffect")]
    private ParticleSystem Player_Heel_Effect1;

    public bool Player_Green_revival_Flag { get; private set; }



    private void Start()
    {
        Player_dead_Flag = false;
        Player_Green_revival_Flag = false;

    }

    void Update()
    {
        if (Gamepad.current == null)
            return;

        var Velocity = Player_Rd_.velocity;

        var GamepadLeftStickValue = Gamepad.all[Player_Numbers_].leftStick.ReadValue();
        var LeftStickvalue = new Vector3(GamepadLeftStickValue.x, 0, GamepadLeftStickValue.y);
        if (LeftStickvalue != Vector3.zero && Player_Hp >= 0)
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

        if (RightStickvalue !=  Vector3.zero &&  Player_Hp >= 0)
        {
            Player_Transform_.transform.localRotation = Quaternion.LookRotation(RightStickvalue);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Heart"))
        {
            if (Player_Hp <= 2)
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
            --Player_Hp;
        }

        //当たったオブジェクトのタグが"Enemy"
        if (collision.gameObject.CompareTag("EnemyW2"))
        {
            Player_health.Health_Function();
            Player_Hp_image.SetActive(true);
            audioSource.PlayOneShot(Player_AudioClip);
            --Player_Hp;
        }

        //当たったオブジェクトのタグが"Enemy"
        if (collision.gameObject.CompareTag("EnemyW3"))
        {
            Player_health.Health_Function();
            Player_Hp_image.SetActive(true);
            audioSource.PlayOneShot(Player_AudioClip);
            --Player_Hp;
        }

      
        if (collision.gameObject.CompareTag("PlayerBlue"))
        {
            if (Player_dead_Flag && Player_Hp <= -1)
            {
                PlayerAnimator.SetBool("Down", false);
                ++Player_Hp;
                Player_health.Player_Recovery_Function();
                player_Blue.PlayerBlue_Recovery_Hp();
                Player_dead_Flag = false;
                Player_Green_revival_Flag = true;
                Player_Heel_Effect1 = Instantiate(Player_Heel_Effect);
                Player_Heel_Effect1.transform.position = this.transform.position;
                Player_Heel_Effect1.Play();
            }
        }

        if (collision.gameObject.CompareTag("PlayerRed"))
        {
            if (Player_dead_Flag && Player_Hp <= -1)
            {
                PlayerAnimator.SetBool("Down", false);
                ++Player_Hp;
                Player_health.Player_Recovery_Function();
                player_Red.PlayerRed_Recovery_Hp();
                Player_dead_Flag = false;
                Player_Green_revival_Flag = true;
                Player_Heel_Effect1 = Instantiate(Player_Heel_Effect);
                Player_Heel_Effect1.transform.position = this.transform.position;
                Player_Heel_Effect1.Play();
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

    public void PlayerGreen_Recovery_Hp()
    {
        Player_Hp -= 1;
        Player_health.Health_Function();
    }
}

