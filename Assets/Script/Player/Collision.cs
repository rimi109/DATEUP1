using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [SerializeField]
    private  float angle = 45f;

    [Tooltip("")]
    private EnemyCollision EnemyHp;

    [Tooltip("")]
    public bool Purple_Attack_ { get; private set; } = false;

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("bluelight"))
        {
            Vector3 posDelta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.forward, posDelta);
            if (target_angle < angle)
            {
             
            }
        }

        if (other.gameObject.CompareTag("Enemy")) 
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
                    }
                    else
                    {
                        Debug.DrawRay(this.transform.position, posDelta.normalized * hit.distance, Color.red);

                        EnemyHp = other.gameObject.GetComponent<EnemyCollision>();
                        EnemyHp.Enemy_Hp_function();
                    }
                }
            }
        }
    }
}
