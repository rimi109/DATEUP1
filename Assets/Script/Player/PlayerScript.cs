using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("PlayerのModelのGameObjectを取得"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Playerが攻撃するときに投げるGameObjectを参照"), SerializeField]
    private GameObject Player_Shot_Object_;

    [Header("PlayerがStunしたときに表示するEffectを参照"), SerializeField]
    private GameObject Player_Stun_Effect;

    [Header("Playerが枕を投げる時に表示するGameObjectを参照"), SerializeField]
    private GameObject Release_makura_;

    [Header("Playerが枕を持っているときに表示するGameObjectを参照"),SerializeField]
    private GameObject Hold_makura_;

    [Header("Playerが攻撃をチャージするときに表示するEffectを参照"),SerializeField]
    private GameObject Player_Charge_Effect_;


    [Header("Player自身のTransformを参照"),SerializeField]
    private Transform Player_Transform_;

    [Header("PlayerがStunしたときに表示するGameObjectのTransformを参照"),SerializeField]
    private Transform Player_Stun_Object_Transform_;

    [Header("Playerが枕を投げる際に枕が発射される位置のGameobjectを参照"),SerializeField]
    private Transform Muzzle_Transform_;


    [Tooltip("PlayerがChage攻撃を溜めている時間")]
    private float Player_Shot_Hold_Time_;

    [Tooltip("Playerが攻撃をくらった時のStun時間")]
    private float Player_Stun_Time_;

    [Header("PlayerのMoveSpeedを参照"), SerializeField]
    private float Player_Move_Speed_;

    [Header("Playerが枕を投げる時のSpeed"), SerializeField]
    private float Player_Pillow_Shot_Speed_;


    [Tooltip("Playerが枕を保持しているかどうかを判定")]
    private bool Player_Hold_Pillow = true;

    [Tooltip("PlayerがStunしているかどうかを判定")]
    private bool Player_Stun_ = false;

    [Tooltip("PlayerがShotを発射可能かどうかを判定")]
    private bool Player_Shot_flag_ = true;

    [Tooltip("PlayerがChargeShotをするとき")]
    private bool Player_Charge_Shot_Speed_Down_ = false;
     

    [Header("Playerが何人目のPlayerかを指定"), SerializeField]
    private int Player_Numbers_;

    [Header("PlayerのRigidbodyを参照"), SerializeField]
    private Rigidbody Player_Rd_;

    [Tooltip("枕に入っているPillowScriptを参照")]
    private PillowScript Pillow_;

    // Update is called once per frame
    void Update()
    {
        if (Player_Stun_)
        {
            Player_Stun_Time_ += Time.deltaTime;

            Player_Stun_Object_Transform_.transform.Rotate(new Vector3(0, 20, 0));

            if (Player_Stun_Time_ > 1)
            {
                Player_Stun_ = false;
                Player_Stun_Effect.SetActive(false);
                Player_Stun_Time_ = 0;
            }

        }

        if (Player_Stun_)
            return;


        if (Gamepad.current == null)
            return;

        var Velocity = Player_Rd_.velocity;

        var GamepadValue = Gamepad.all[Player_Numbers_].leftStick.ReadValue();
        var value = new Vector3(GamepadValue.x, 0, GamepadValue.y);
        if (value != Vector3.zero && !Player_Charge_Shot_Speed_Down_)
        {
            Player_Transform_.transform.localRotation = Quaternion.LookRotation(value);
            Velocity = value * Player_Move_Speed_;

        }
        else if (value != Vector3.zero && Player_Charge_Shot_Speed_Down_)
        {
            Player_Transform_.transform.localRotation = Quaternion.LookRotation(value);
            Velocity = value * Player_Move_Speed_ / 2;
        }
        else
        {
            Velocity = Vector3.zero;
        }


        Player_Rd_.velocity = Velocity;

        if (!Player_Shot_flag_)
            return;

        if (Gamepad.all[Player_Numbers_].aButton.isPressed)
        {

            Player_Shot_Hold_Time_ += Time.deltaTime;

            Player_Charge_Effect_.SetActive(true);

            if (Player_Shot_Hold_Time_ < 0.7f)
            {

                Player_Pillow_Shot_Speed_ = 10;


            }
            else if (Player_Shot_Hold_Time_ < 1.4f)

            {

                Player_Pillow_Shot_Speed_ = 30;
            }
            else
            {
                Player_Pillow_Shot_Speed_ = 45;

            }

            Release_makura_.SetActive(true);
            Hold_makura_.SetActive(false);
            Player_Charge_Shot_Speed_Down_ = true;
        }

        if (Gamepad.all[Player_Numbers_].aButton.wasReleasedThisFrame)
        {
            Player_Is_Shot_Function();
            Player_Shot_flag_ = false;
            Release_makura_.SetActive(false);
            Player_Hold_Pillow = false;
            Player_Charge_Shot_Speed_Down_ = false;
            Player_Pillow_Shot_Speed_ = 0;
            Player_Shot_Hold_Time_ = 0;
            Player_Charge_Effect_.SetActive(false);
        }

    }
    private void Player_Is_Shot_Function()
    {
        GameObject ball = (GameObject)Instantiate(Player_Shot_Object_, Muzzle_Transform_.position, Player_Transform_.rotation);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(Player_Transform_.forward * Player_Pillow_Shot_Speed_, ForceMode.Impulse);
    }

    private void Stun_Function_()
    {
        Player_Stun_ = true;
        Player_Stun_Effect.SetActive(true);
        Pillow_.Pillow_No_Attack_Function();
    }
}

