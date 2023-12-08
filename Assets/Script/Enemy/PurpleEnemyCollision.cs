using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemyCollision : MonoBehaviour
{
    [Tooltip("赤色のライトが当たっているかを判定")]
    private bool Red_Attack_Flag;

    [Tooltip("青色のライトが当たっているかを判定")]
    private bool Blue_Attack_Flag;

    [Tooltip("紫色のライトが当たっているかを判定")]
    private RedLightCollision Player_Purple_Flag;

    private void Start()
    {
        Red_Attack_Flag  = false;
        Blue_Attack_Flag = false;
    }

    void Update()
    {
        if (Blue_Attack_Flag && Red_Attack_Flag && Player_Purple_Flag.Purple_Attack_Flag)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("redlight"))
        {
            Red_Attack_Flag = true;
            Player_Purple_Flag = other.gameObject.GetComponent<RedLightCollision>();
        }

        if (other.gameObject.CompareTag("bluelight"))
        {
            Blue_Attack_Flag = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("redlight"))
        {
            Red_Attack_Flag = false;
        }

        if (other.gameObject.CompareTag("bluelight"))
        {
            Blue_Attack_Flag = false;
        }
    }
}
