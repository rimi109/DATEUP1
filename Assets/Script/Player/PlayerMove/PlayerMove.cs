using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    [Header("Player自身のTransformを参照"), SerializeField]
    private Transform Player_Transform;

    [Header("PlayerのMoveSpeedを参照"), SerializeField]
    private float Player_Move_Speed;

    [Header("Playerが何人目のPlayerかを指定"), SerializeField]
    private int Player_Numbers;

    [Header("PlayerのRigidbodyを参照"), SerializeField]
    private Rigidbody Player_Rd;

    [Header("PlayerのAnimatorを参照"), SerializeField]
    private Animator Player_Animator;


    void Update()
    {
        if (Gamepad.current == null)
            return;

        Player_Move();

    }

    #region　Playerが動く際に実行するプログラム
    /// <summary>
    /// Playerが動く際に実行するプログラム
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
