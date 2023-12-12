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

    [Tooltip("PlayerがStunしているかどうかを判定")]
    private bool Player_Stun_ = false;
     

    [Header("Playerが何人目のPlayerかを指定"), SerializeField]
    private int Player_Numbers_;

    [Header("PlayerのRigidbodyを参照"), SerializeField]
    private Rigidbody Player_Rd_;

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

        var GamepadLeftStickValue = Gamepad.all[Player_Numbers_].leftStick.ReadValue();
        var LeftStickvalue = new Vector3(GamepadLeftStickValue.x, 0, GamepadLeftStickValue.y);
        if (LeftStickvalue != Vector3.zero)
        {
            Velocity = LeftStickvalue * Player_Move_Speed_;

        }
        else
        {
            Velocity = Vector3.zero;
        }

        Player_Rd_.velocity = Velocity;

        var GamepadrightStickValue = Gamepad.all[Player_Numbers_].rightStick.ReadValue();
        var RightStickvalue = new Vector3(GamepadrightStickValue.x, 0, GamepadrightStickValue.y);
        if (RightStickvalue !=  Vector3.zero)
        {
            Player_Transform_.transform.localRotation = Quaternion.LookRotation(RightStickvalue);
        }
    }
}

