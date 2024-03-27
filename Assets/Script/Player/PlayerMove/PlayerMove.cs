using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    [Header("Player���g��Transform���Q��"), SerializeField]
    private Transform Player_Transform;

    [Header("Player��MoveSpeed���Q��"), SerializeField]
    private float Player_Move_Speed;

    [Header("Player�����l�ڂ�Player�����w��"), SerializeField]
    private int Player_Numbers;

    [Header("Player��Rigidbody���Q��"), SerializeField]
    private Rigidbody Player_Rd;

    [Header("Player��Animator���Q��"), SerializeField]
    private Animator Player_Animator;


    void Update()
    {
        if (Gamepad.current == null)
            return;

        Player_Move();

    }

    #region�@Player�������ۂɎ��s����v���O����
    /// <summary>
    /// Player�������ۂɎ��s����v���O����
    /// </summary>
    private void Player_Move()
    {
        var Velocity = Player_Rd.velocity;
        var GamepadLeftStickValue = Gamepad.all[Player_Numbers].leftStick.ReadValue();
        var LeftStickvalue = new Vector3(GamepadLeftStickValue.x, 0, GamepadLeftStickValue.y);
        if (LeftStickvalue != Vector3.zero)
        {
            Velocity = LeftStickvalue * Player_Move_Speed;
            Player_Animator.SetBool("walk", true);
        }
        else
        {
            Velocity = Vector3.zero;
            Player_Animator.SetBool("walk", false);
        }

        Player_Rd.velocity = Velocity;

        var GamepadrightStickValue = Gamepad.all[Player_Numbers].rightStick.ReadValue();
        var RightStickvalue = new Vector3(GamepadrightStickValue.x, 0, GamepadrightStickValue.y);

        if (RightStickvalue != Vector3.zero)
        {
            Player_Transform.transform.localRotation = Quaternion.LookRotation(RightStickvalue);
        }
    }
    #endregion
}
