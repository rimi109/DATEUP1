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

    [Tooltip("Player��Stun���Ă��邩�ǂ����𔻒�")]
    private bool Player_Stun_ = false;
     

    [Header("Player�����l�ڂ�Player�����w��"), SerializeField]
    private int Player_Numbers_;

    [Header("Player��Rigidbody���Q��"), SerializeField]
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

