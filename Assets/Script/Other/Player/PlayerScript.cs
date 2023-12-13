using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    [SerializeField]
    private EnemyGenerate EnemySystem;

    [SerializeField]
    private Wave1 Wave1System;

    [SerializeField]
    private Wave2 Wave2System;

    [SerializeField]
    private Wave3 Wave3System;

    [Header("Player��Model��GameObject���擾"), SerializeField]
    private GameObject This_Player_GameObject;

    [Header("Player���g��Transform���Q��"),SerializeField]
    private Transform Player_Transform_;

    [Header("Player��MoveSpeed���Q��"), SerializeField]
    private float Player_Move_Speed_;

    [Header("Player�����l�ڂ�Player�����w��"), SerializeField]
    private int Player_Numbers_;

    [Header("Player��Rigidbody���Q��"), SerializeField]
    private Rigidbody Player_Rd_;

    [Header("Player��Animator���Q��"), SerializeField]
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

    void OnCollisionEnter(Collision collision)
    {
        //���������I�u�W�F�N�g�̃^�O��"Enemy"
        if (collision.gameObject.CompareTag("EnemyW1"))
        {
            //�Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);
            EnemySystem.wave1Count();
            Wave1System.CountW1();
        }

        //���������I�u�W�F�N�g�̃^�O��"Enemy"
        if (collision.gameObject.CompareTag("EnemyW2"))
        {
            //�Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);
            EnemySystem.wave2Count();
            Wave2System.CountW2();
        }

        //���������I�u�W�F�N�g�̃^�O��"Enemy"
        if (collision.gameObject.CompareTag("EnemyW3"))
        {
            //�Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);
            Wave3System.CountW3();
        }
    }

}

