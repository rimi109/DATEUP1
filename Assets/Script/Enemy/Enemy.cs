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

    private bool Anime;
    private bool EffectStart;
    private bool Effect;

    [Tooltip("")]
    public  List<GameObject> Players = new List<GameObject>();

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

        agent = GetComponent<NavMeshAgent>();
        this.rb = GetComponent<Rigidbody>();

        AddPlayersToList();

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
        GameObject closestPlayer = null;

        for (int i = 0; i < Players.Count; i++)
        {
            float playerDistance = Vector3.Distance(transform.position, Players[i].transform.position);

            if (playerDistance < closestPlayerDistance)
            {
                closestPlayerDistance = playerDistance;
                closestPlayer = Players[i];
            }
        }

        if (closestPlayer != null)
        {
            agent.destination = closestPlayer.transform.position;
            agent.speed = 10.0f;
        }
    }
    void AddPlayersToList()
    {
        GameObject[] PlayerGreen = GameObject.FindGameObjectsWithTag("PlayerGreen");
        GameObject[] PlayerRed = GameObject.FindGameObjectsWithTag("PlayerRed");
        GameObject[] PlayerBlue = GameObject.FindGameObjectsWithTag("PlayerBlue");

        Players.AddRange(PlayerGreen);
        Players.AddRange(PlayerRed);
        Players.AddRange(PlayerBlue);
    }

    public void Erase_dead_Players()
    {

        Players.RemoveAll(player => player.GetComponent<PlayerScript>() != null && player.GetComponent<PlayerScript>().Player_dead_Flag);
    }
}