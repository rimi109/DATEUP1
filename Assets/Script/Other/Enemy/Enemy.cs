using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;

    int HP = 10;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        target1 = GameObject.Find("Player1");
        target2 = GameObject.Find("Player2");
        target3 = GameObject.Find("Player3");
    }

    void Update()
    {
        //Enemy��Player�̋����𒲂ׂ�
        float dis1 = Vector3.Distance(this.transform.position, target1.transform.position);
        float dis2 = Vector3.Distance(this.transform.position, target2.transform.position);
        float dis3 = Vector3.Distance(this.transform.position, target3.transform.position);

        //Player1��1�ԋ߂�������Player1��ǂ�������
        if (dis1 < dis2 && dis1 < dis3)
        {
            agent.destination = target1.transform.position;
        }
        //Player2��1�ԋ߂�������Player2��ǂ�������
        if (dis2 < dis1 && dis2 < dis3)
        {
            agent.destination = target2.transform.position;
        }
        //Player3��1�ԋ߂�������Player3��ǂ�������
        if (dis3 < dis1 && dis3 < dis2)
        {
            agent.destination = target3.transform.position;
        }
       
    }

}