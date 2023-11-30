using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [SerializeField]
    private  float angle = 45f;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
          
            Vector3 posDelta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.forward, posDelta);

            if (target_angle < angle)
            {
                if (Physics.Raycast(this.transform.position, posDelta, out RaycastHit hit)) 
                {
                    if (hit.collider.CompareTag("Wall"))
                    {
                        //Debug.DrawRay(origin, direction * hit.distance, Color.red);
                    }

                    if (hit.collider == other)
                    {
                        Debug.Log("Œ³‹I");
                    }
                }
            }
        }
    }
}
