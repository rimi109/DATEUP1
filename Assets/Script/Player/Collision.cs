using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [SerializeField]
    private  float angle = 45f;


    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player")) 
        {
            Vector3 posDelta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.forward, posDelta);
            
            if (target_angle < angle)
            {
                if (Physics.Raycast(this.transform.position, posDelta,  out RaycastHit hit)) 
                {
                    if (hit.collider.CompareTag("Wall"))
                    {
                        Debug.DrawRay(this.transform.position, posDelta.normalized * hit.distance, Color.red);
                        Debug.Log("ƒtƒL");
                    }
                    else
                    {
                        Debug.DrawRay(this.transform.position, posDelta.normalized * hit.distance, Color.red);
                        Debug.Log("Œ³‹I");
                    }
                }
            }
        }
    }
}
