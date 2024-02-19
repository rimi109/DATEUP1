using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
//using UnityEngine.ProBuilder.Shapes;

public class Enemy : MonoBehaviour
{
    //Ä¶‚µ‚½‚¢Effect‚ğQÆ
    [SerializeField]
    private ParticleSystem particle;

    //Ä¶‚µ‚½‚¢Animation‚ğQÆ]
    public GameObject anime;

    private bool Anime;
    private bool EffectStart;
    private bool Effect;

    private NavMeshAgent agent;
    public CapsuleCollider col;
    public Renderer MeshRen;

    [Header("PlayerManager‚ÌScript‚ğæ“¾"),SerializeField]
    private PlayerManager Player_Manager;

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

        agent = GetComponent<NavMeshAgent>();
        Player_Manager = FindObjectOfType<PlayerManager>();
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


        float closestPlayerDistance = float.MaxValue;
        Transform closestPlayer = null;


        for (int i = 0; i < Player_Manager.Players.Count; i++)
        {
            float playerDistance = Vector3.Distance(transform.position, Player_Manager.Players[i].transform.position);

            if (playerDistance < closestPlayerDistance)
            {
                closestPlayerDistance = playerDistance;
                closestPlayer = Player_Manager.Players[i];
            }
        }

        if (closestPlayer != null)
        {
            agent.destination = closestPlayer.transform.position;
            agent.speed = 10.0f;
        }
    }
}