using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlueEnemyCollision : MonoBehaviour
{
    [Tooltip("緑のライトが当たっているかを判定")]
    private bool Green_Attack_Flag;

    [Tooltip("青色のライトが当たっているかを判定")]
    private bool Blue_Attack_Flag;

    [Tooltip("緑色のライトが当たっているかを判定")]
    private BlueLightCollision Player_Blue_Flag;

    private void Start()
    {
        Green_Attack_Flag = false;
        Blue_Attack_Flag = false;
    }

    void Update()
    {
        if (Blue_Attack_Flag && Green_Attack_Flag && Player_Blue_Flag.Light_Blue_Attack_Flag)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("bluelight"))
        {
            Green_Attack_Flag = true;
            Player_Blue_Flag = other.gameObject.GetComponent<BlueLightCollision>();
        }

        if (other.gameObject.CompareTag("greenlight"))
        {
            Blue_Attack_Flag = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("greenlight"))
        {
            Green_Attack_Flag = false;
        }

        if (other.gameObject.CompareTag("bluelight"))
        {
            Blue_Attack_Flag = false;
        }
    }
}
