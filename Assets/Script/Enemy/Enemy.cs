using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.ProBuilder.Shapes;

public class Enemy : MonoBehaviour
{
    public GameObject targetR;
    public GameObject targetG;
    public GameObject targetB;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float disR = Vector3.Distance(this.transform.position, targetR.transform.position);
        float disG = Vector3.Distance(this.transform.position, targetG.transform.position);
        float disB = Vector3.Distance(this.transform.position, targetB.transform.position);

        if (disR < disG && disR < disB)
        {
            agent.destination = targetR.transform.position;
        }

        if (disG < disR && disG < disB)
        {
            agent.destination = targetG.transform.position;
        }

        if (disB < disR && disB < disG)
        {
            agent.destination = targetB.transform.position;
        }
    }
}