using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
//using UnityEngine.ProBuilder.Shapes;

public class Enemy : MonoBehaviour
{
    //çƒê∂ÇµÇΩÇ¢EffectÇéQè∆
    [SerializeField]
    private ParticleSystem particle;

    private bool EffectStart;
    private bool Effect;

    public GameObject targetR;
    public GameObject targetG;
    public GameObject targetB;

    private Rigidbody rb;

    private NavMeshAgent agent;
    public CapsuleCollider col;

    private float EffectTime = 0.0f;

    void Start()
    {
        EffectStart = false;
        Effect = false;
        col.enabled = false;

        agent = GetComponent<NavMeshAgent>();
        this.rb = GetComponent<Rigidbody>();

        targetR = GameObject.Find("Player1");
        targetG = GameObject.Find("Player2");
        targetB = GameObject.Find("Player3");
    }

    void Update()
    {
        if (!Effect)
        {
            if (!EffectStart)
            {
                ParticleSystem newParticle = Instantiate(particle);
                newParticle.transform.position = this.transform.position;
                newParticle.Play();
                Destroy(newParticle, 1.0f);
                EffectTime += 1.0f * Time.deltaTime;
                Effect = true;

                if (EffectTime >= 1.0f)
                {
                    EffectStart = true;
                }
            }
        }

        if (!EffectStart && !Effect)
            return;

        col.enabled = true;

        float disR = Vector3.Distance(this.transform.position, targetR.transform.position);
        float disG = Vector3.Distance(this.transform.position, targetG.transform.position);
        float disB = Vector3.Distance(this.transform.position, targetB.transform.position);

        //this.rb.AddForce(new Vector3(1, 3, 4f), ForceMode.Force);

        if (disR < disG && disR < disB)
        {
            agent.destination = targetR.transform.position;
            agent.speed = 10.0f;
        }

        else if (disG < disR && disG < disB)
        {
            agent.destination = targetG.transform.position;
            agent.speed = 10.0f;
        }

        else
        {
            agent.destination = targetB.transform.position;
            agent.speed = 10.0f;
        }
    }
}