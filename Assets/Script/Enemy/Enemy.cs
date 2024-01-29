using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
//using UnityEngine.ProBuilder.Shapes;

public class Enemy : MonoBehaviour
{
    //çƒê∂ÇµÇΩÇ¢EffectÇéQè∆
    [SerializeField]
    private ParticleSystem particle;

    //çƒê∂ÇµÇΩÇ¢AnimationÇéQè∆]
    public GameObject anime;

    private bool PlayerHit;
    private bool Anime;
    private bool EffectStart;
    private bool Effect;

    public GameObject targetR;
    public GameObject targetG;
    public GameObject targetB;

    private Rigidbody rb;

    private NavMeshAgent agent;
    public CapsuleCollider col;
    public Renderer MeshRen;

    private float EffectTime;
    private float AnimeTime;

    void Start()
    {
        EffectTime = 0.0f;
        AnimeTime  = 0.0f;

        Anime = false; 
        EffectStart = false;
        Effect = false;
        col.enabled = false;
        PlayerHit = false;

        agent = GetComponent<NavMeshAgent>();
        this.rb = GetComponent<Rigidbody>();

        targetR = GameObject.Find("PlayerRed");
        targetG = GameObject.Find("GreenPlayer");
        targetB = GameObject.Find("PlayerBlue");
    }

    void Update()
    {
        AnimeTime += 1.0f * Time.deltaTime;

        if(!Anime)
        {
            GameObject newAnim = Instantiate(anime);
            newAnim.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 10, this.transform.position.z);
            Anime = true;
        }

        if (!Effect && AnimeTime >= 2.0f)
        {
            if (!EffectStart)
            {
                ParticleSystem newParticle = Instantiate(particle);
                newParticle.transform.position = this.transform.position;
                newParticle.Play();
                Destroy(newParticle, 1.0f);
                EffectTime += 1.0f * Time.deltaTime;
                Effect = true;
                MeshRen.enabled = true;

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


        if (disR < disG && disR < disB && !PlayerHit)
        {
            agent.destination = targetR.transform.position;
            agent.speed = 10.0f;    
        }

        else if (disG < disR && disG < disB && !PlayerHit)
        {
            agent.destination = targetG.transform.position;
            agent.speed = 10.0f;
        }

        else if(!PlayerHit)
        {
            agent.destination = targetB.transform.position;
            agent.speed = 10.0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerGreen"))
        {
            agent.speed = 0.0f;
            PlayerHit = true;
        }
        else if (collision.gameObject.CompareTag("PlayerRed"))
        {
            agent.speed = 0.0f;
            PlayerHit = true;
        }
        else if (collision.gameObject.CompareTag("PlayerBlue"))
        {
            agent.speed = 0.0f;
            PlayerHit = true;
        }
    }

     void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHit = false;
        }
    }
}