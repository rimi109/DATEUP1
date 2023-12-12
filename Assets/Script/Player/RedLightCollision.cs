using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightCollision : MonoBehaviour
{

    [SerializeField]
    private  float angle;

    [Tooltip("")]
    public boolÅ@Purple_Attack_Flag { get; private set; } = false;

    private void OnTriggerStay(Collider other)
    {


        if (other.gameObject.CompareTag("bluelight"))
        {
            Vector3 posDelta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.forward, posDelta);
            float taget_position = (posDelta).magnitude;
            if (target_angle < angle)
            {
                if (taget_position < 95)
                {
                    Purple_Attack_Flag = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("bluelight"))
        {
            Purple_Attack_Flag = false;
        }
    }
}
