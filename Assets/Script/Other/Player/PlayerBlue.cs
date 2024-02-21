using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlue : MonoBehaviour
{
    [Header(""), SerializeField]
    private EnemyGenerate EnemyGenerateSystem;

    [Header(""), SerializeField]
    private Wave1 GameWave1;

    [Header(""), SerializeField]
    private Wave2 GameWave2;

    [Header(""), SerializeField]
    private Wave3 GameWave3;

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

    public bool Player_Blue_Dead_Flag;
    public bool Player_Blue_revival_Flag { get; private set; }

    private void Start()
    {
        Player_Blue_Dead_Flag = false;
        Player_Blue_revival_Flag = false;
    }

    void Update()
    {
        if (Gamepad.current == null)
            return;

        var Velocity = Player_Rd_.velocity;

        var GamepadLeftStickValue = Gamepad.all[Player_Numbers_].leftStick.ReadValue();
        var LeftStickvalue = new Vector3(GamepadLeftStickValue.x, 0, GamepadLeftStickValue.y);
        if (LeftStickvalue != Vector3.zero && Player_Hp > 0)
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

        if (RightStickvalue != Vector3.zero && Player_Hp > 0)
        {
            Player_Transform_.transform.localRotation = Quaternion.LookRotation(RightStickvalue);
        }
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
                player_Green.PlayerGreen_Recovery_Hp();
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
                player_Red.PlayerRed_Recovery_Hp();
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

    public void PlayerBlue_Recovery_Hp()
    {
        Player_Hp -= 1;
        Player_health.Health_Function();
    }
}
