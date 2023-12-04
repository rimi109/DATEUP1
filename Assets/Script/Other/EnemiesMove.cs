using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemiesMove : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    public GameObject target1;

    [SerializeField]
    public GameObject target2;

    [SerializeField]
    public GameObject target3;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float dis1 = Vector3.Distance(this.transform.position, target1.transform.position);
        float dis2 = Vector3.Distance(this.transform.position, target2.transform.position);
        float dis3 = Vector3.Distance(this.transform.position, target3.transform.position);

        if (dis1 < dis2 || dis1 < dis3)
        {
            agent.destination = target1.transform.position;
        }
        
        if (dis2 < dis1 || dis2 < dis3)
        {
            agent.destination = target2.transform.position;
        }
        
        if (dis3 < dis1 || dis3 < dis2) 
        {
            agent.destination = target3.transform.position;
        }
    }

}