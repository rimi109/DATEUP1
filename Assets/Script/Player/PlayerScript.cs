using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("PlayerのModelのGameObjectを取得"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Player自身のTransformを参照"),SerializeField]
    private Transform Player_Transform_;

    [Header("PlayerのMoveSpeedを参照"), SerializeField]
    private float Player_Move_Speed_;

    [Header("Playerが何人目のPlayerかを指定"), SerializeField]
    private int Player_Numbers_;

    [Header("PlayerのRigidbodyを参照"), SerializeField]
    private Rigidbody Player_Rd_;

    [Header("PlayerのAnimatorを参照"), SerializeField]
    private Animator PlayerAnimator;

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current == null)
            return;

        var Velocity = Player_Rd_.velocity;

        var GamepadLeftStickValue = Gamepad.all[Player_Numbers_].leftStick.ReadValue();
        var LeftStickvalue = new Vector3(GamepadLeftStickValue.x, 0, GamepadLeftStickValue.y);
        if (LeftStickvalue != Vector3.zero)
        {
            Velocity = LeftStickvalue * Player_Move_Speed_;
            PlayerAnimator.SetBool("walk",true);
        }
        else
        {
            Velocity = Vector3.zero;
            PlayerAnimator.SetBool("walk", false);
        }

        Player_Rd_.velocity = Velocity;

        var GamepadrightStickValue = Gamepad.all[Player_Numbers_].rightStick.ReadValue();
        var RightStickvalue = new Vector3(GamepadrightStickValue.x, 0, GamepadrightStickValue.y);
        if (RightStickvalue !=  Vector3.zero)
        {
            Player_Transform_.transform.localRotation = Quaternion.LookRotation(RightStickvalue);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }
}

