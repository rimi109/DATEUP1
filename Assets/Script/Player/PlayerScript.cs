using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Playerが枕を持っているときに表示するGameObjectを参照"),SerializeField]
    private GameObject Hold_makura_;

    [Header("Playerが枕を投げる時に表示するGameObjectを参照"),SerializeField]
    private GameObject Release_makura_;

    [Header("Playerが攻撃をチャージするときに表示するEffectを参照"),SerializeField]
    private GameObject Player_Charge_Effect_;

    [Header("Playerが攻撃するときに投げるGameObjectを参照"),SerializeField]
    private GameObject Player_Shot_Object_;

    [Header("PlayerがStunしたときに表示するGameObejctを参照"),SerializeField]
    private GameObject Stun_Hiyoko_;

    [Header("Player自身のTransformを参照"),SerializeField]
    private Transform Player_Transform_;

    [Header("PlayerがStunしたときに表示するGameObjectのTransformを参照"),SerializeField]
    private Transform Stun_Hiyoko_Transform_;

    [Header("Playerの枕を投げる発射"),SerializeField]
    private Transform Muzzle_Transform_;


    [Header(""),SerializeField]
    private Rigidbody Player_Rd_;


    [Header(""),SerializeField]
    private float Player_Shot_Speed_;

    [Header(""),SerializeField]
    private float Move_Speed_;

    [Tooltip("")]
    private float Player_Shot_Hold_TIme_;

    [Tooltip("")]
    private float Shot_Speed_;

    [Tooltip("")]
    private float Stun_Time_;


    [Header(""),SerializeField]
    private int Player_Numbers_;


    [Tooltip("")]
    bool Shot_flag_ = true;

    [Tooltip("")]
    bool Stun_ = false;

    [Tooltip("")]
    bool Hold_ = true;

    [Tooltip("")]
    bool Speed_Down_ = false;


    [Header(""),SerializeField]
    private Animator Player_Animation_;

    [Tooltip("")]
    private PillowScript Pilllo_2;

    // Update is called once per frame
    void Update()
    {
        if (Stun_)
        {
            Stun_Time_ += Time.deltaTime;

            Stun_Hiyoko_Transform_.transform.Rotate(new Vector3(0, 20, 0));

            if (Stun_Time_ > 1)
            {
                Stun_ = false;
                Stun_Hiyoko_.SetActive(false);
                Stun_Time_ = 0;
            }

        }

        if (Stun_)

            return;


        if (Gamepad.current == null)
            return;

        var Velocity = Player_Rd_.velocity;

        var GamepadValue = Gamepad.all[Player_Numbers_].leftStick.ReadValue();
        var value = new Vector3(GamepadValue.x, 0, GamepadValue.y);
        if (value != Vector3.zero && !Speed_Down_)
        {
            Player_Transform_.transform.localRotation = Quaternion.LookRotation(value);
            Velocity = value * Move_Speed_;

        }
        else if (value != Vector3.zero && Speed_Down_)
        {
            Player_Transform_.transform.localRotation = Quaternion.LookRotation(value);
            Velocity = value * Move_Speed_ / 2;
        }
        else
        {
            Velocity = Vector3.zero;
        }


        Player_Rd_.velocity = Velocity;

        if (!Shot_flag_)
            return;

        if (Gamepad.all[Player_Numbers_].aButton.isPressed)
        {

            Player_Shot_Hold_TIme_ += Time.deltaTime;
            Player_Animation_.SetBool("PlayerAttack", true);

            Player_Charge_Effect_.SetActive(true);

            if (Player_Shot_Hold_TIme_ < 0.7f)
            {

                Shot_Speed_ = 10;


            }
            else if (Player_Shot_Hold_TIme_ < 1.4f)

            {

                Shot_Speed_ = 30;
            }
            else
            {
                Shot_Speed_ = 45;

            }

            Release_makura_.SetActive(true);
            Hold_makura_.SetActive(false);
            Speed_Down_ = true;
        }

        if (Gamepad.all[Player_Numbers_].aButton.wasReleasedThisFrame)
        {
            Player_Is_Shot_Function();
            Shot_flag_ = false;
            Release_makura_.SetActive(false);
            Hold_ = false;
            Speed_Down_ = false;
            Shot_Speed_ = 0;
            Player_Shot_Hold_TIme_ = 0;
            Player_Animation_.SetBool("PlayerAttack", false);
            Player_Charge_Effect_.SetActive(false);
        }

    }
    private void Player_Is_Shot_Function()
    {
        GameObject ball = (GameObject)Instantiate(Player_Shot_Object_, Muzzle_Transform_.position, Player_Transform_.rotation);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(Player_Transform_.forward * Shot_Speed_, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Stun_)
            return;

        if (collision.gameObject.CompareTag("MakuraOne"))
        {

            Pilllo_2 = collision.gameObject.GetComponent<PillowScript>();

            if (!Pilllo_2.Pillow_Attack_ && !Hold_)
            {
                Hold_ = true;
                Shot_flag_ = true;
                Hold_makura_.SetActive(true);
                Destroy(collision.gameObject);
            }

            if (!Pilllo_2.Pillow_Attack_)
            {
                Pilllo_2.Pillow_Attack_Function();
            }
        }

        if (collision.gameObject.CompareTag("MakuraTwo"))
        {

            Pilllo_2 = collision.gameObject.GetComponent<PillowScript>();

            if (!Pilllo_2.Pillow_Attack_ && !Hold_)
            {
                Hold_ = true;
                Shot_flag_ = true;
                Hold_makura_.SetActive(true);
                Destroy(collision.gameObject);
            }

            if (Pilllo_2.Pillow_Attack_)
            {
                Stun_Function_();
                
            }
            else
            {
                Pilllo_2.Pillow_Attack_Function();
            }
        }

        if (collision.gameObject.CompareTag("MakuraThree"))
        {

            Pilllo_2 = collision.gameObject.GetComponent<PillowScript>();

            if (!Pilllo_2.Pillow_Attack_ && !Hold_)
            {
                Hold_ = true;
                Shot_flag_ = true;
                Hold_makura_.SetActive(true);
                Destroy(collision.gameObject);
            }

            if (Pilllo_2.Pillow_Attack_)
            {
                Stun_Function_();
            
            }
            else
            {
                Pilllo_2.Pillow_Attack_Function();
            }
        }

        if (collision.gameObject.CompareTag("MakuraFour"))
        {

            Pilllo_2 = collision.gameObject.GetComponent<PillowScript>();

            if (!Pilllo_2.Pillow_Attack_ && !Hold_)
            {
                Hold_ = true;
                Shot_flag_ = true;
                Hold_makura_.SetActive(true);
                Destroy(collision.gameObject);
            }

            if (Pilllo_2.Pillow_Attack_)
            {
                Stun_Function_();
            }
            else
            {
                Pilllo_2.Pillow_Attack_Function();
            }
        }
    }

    private void Stun_Function_()
    {
        Stun_ = true;
        Stun_Hiyoko_.SetActive(true);
        Pilllo_2.Pillow_No_Attack_Function();
    }
}

