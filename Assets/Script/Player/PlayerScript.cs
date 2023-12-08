using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Player��Model��GameObject���擾"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Player���U������Ƃ��ɓ�����GameObject���Q��"), SerializeField]
    private GameObject Player_Shot_Object_;

    [Header("Player��Stun�����Ƃ��ɕ\������Effect���Q��"), SerializeField]
    private GameObject Player_Stun_Effect;

    [Header("Player�����𓊂��鎞�ɕ\������GameObject���Q��"), SerializeField]
    private GameObject Release_makura_;

    [Header("Player�����������Ă���Ƃ��ɕ\������GameObject���Q��"),SerializeField]
    private GameObject Hold_makura_;

    [Header("Player���U�����`���[�W����Ƃ��ɕ\������Effect���Q��"),SerializeField]
    private GameObject Player_Charge_Effect_;


    [Header("Player���g��Transform���Q��"),SerializeField]
    private Transform Player_Transform_;

    [Header("Player��Stun�����Ƃ��ɕ\������GameObject��Transform���Q��"),SerializeField]
    private Transform Player_Stun_Object_Transform_;

    [Header("Player�����𓊂���ۂɖ������˂����ʒu��Gameobject���Q��"),SerializeField]
    private Transform Muzzle_Transform_;


    [Tooltip("Player��Chage�U���𗭂߂Ă��鎞��")]
    private float Player_Shot_Hold_Time_;

    [Tooltip("Player���U���������������Stun����")]
    private float Player_Stun_Time_;

    [Header("Player��MoveSpeed���Q��"), SerializeField]
    private float Player_Move_Speed_;

    [Header("Player�����𓊂��鎞��Speed"), SerializeField]
    private float Player_Pillow_Shot_Speed_;


    [Tooltip("Player������ێ����Ă��邩�ǂ����𔻒�")]
    private bool Player_Hold_Pillow = true;

    [Tooltip("Player��Stun���Ă��邩�ǂ����𔻒�")]
    private bool Player_Stun_ = false;

    [Tooltip("Player��Shot�𔭎ˉ\���ǂ����𔻒�")]
    private bool Player_Shot_flag_ = true;

    [Tooltip("Player��ChargeShot������Ƃ�")]
    private bool Player_Charge_Shot_Speed_Down_ = false;
     

    [Header("Player�����l�ڂ�Player�����w��"), SerializeField]
    private int Player_Numbers_;

    [Header("Player��Rigidbody���Q��"), SerializeField]
    private Rigidbody Player_Rd_;

    [Tooltip("���ɓ����Ă���PillowScript���Q��")]
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

