using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemyCollision : MonoBehaviour
{
    [Tooltip("�΂̃��C�g���������Ă��邩�𔻒�")]
    private bool Green_Attack_Flag;

    [Tooltip("�ԐF�̃��C�g���������Ă��邩�𔻒�")]
    private bool red_Attack_Flag;

    [Tooltip("�ΐF�̃��C�g���������Ă��邩�𔻒�")]
    private GreenLightCollision Player_Green_Flag;

    private void Start()
    {
        Green_Attack_Flag = false;
        red_Attack_Flag = false;
    }

    void Update()
    {
        if (red_Attack_Flag && Green_Attack_Flag && Player_Green_Flag.Yellow_Attack_Flag)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("greenlight"))
        {
            Green_Attack_Flag = true;
            Player_Green_Flag = other.gameObject.GetComponent<GreenLightCollision>();
        }

        if (other.gameObject.CompareTag("redlight"))
        {
            red_Attack_Flag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("greenlight"))
        {
            Green_Attack_Flag = false;
        }

        if (other.gameObject.CompareTag("redlight"))
        {
            red_Attack_Flag = false;
        }
    }
}
