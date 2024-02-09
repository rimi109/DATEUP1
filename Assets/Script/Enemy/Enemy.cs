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
    private PlayerScript PlayerGreen;
    private PlayerBlue PlayerBlue;
    private PlayerRed PlayerRed;

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
        PlayerGreen =  GameObject.Find("GreenPlayer").GetComponent<PlayerScript>();
        PlayerRed   = GameObject.Find("PlayerRed").GetComponent<PlayerRed>();
        PlayerBlue  = GameObject.Find("PlayerBlue").GetComponent<PlayerBlue>();
        Add_Players_ToList();

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

        if (PlayerGreen.Player_Green_revival_Flag)
        {
            PlayerGreen_revival_function();
        }

        if (PlayerRed.Player_Red_revival_Flag)
        {
            PlayerRed_revival_function();
        }

        if (PlayerBlue.Player_Blue_revival_Flag)
        {
            PlayerBlue_revival_function();
        }

        if (!EffectStart && !Effect)
            return;

        col.enabled = true;


        float closestPlayerDistance = float.MaxValue;
        GameObject closestPlayer = null;

        Players.RemoveAll(playerGreen => playerGreen.GetComponent<PlayerScript>() != null && playerGreen.GetComponent<PlayerScript>().Player_dead_Flag);
        Players.RemoveAll(playerBlue => playerBlue.GetComponent<PlayerBlue>() != null && playerBlue.GetComponent<PlayerBlue>().Player_dead_Flag);
        Players.RemoveAll(playerRed => playerRed.GetComponent<PlayerRed>() != null && playerRed.GetComponent<PlayerRed>().Player_dead_Flag);


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
    void Add_Players_ToList()
    {
        GameObject[] PlayerGreen = GameObject.FindGameObjectsWithTag("PlayerGreen");
        GameObject[] PlayerRed = GameObject.FindGameObjectsWithTag("PlayerRed");
        GameObject[] PlayerBlue = GameObject.FindGameObjectsWithTag("PlayerBlue");

        Players.AddRange(PlayerGreen);
        Players.AddRange(PlayerRed);
        Players.AddRange(PlayerBlue);
    }

    void PlayerGreen_revival_function()
    {
        GameObject[] PlayerGreen = GameObject.FindGameObjectsWithTag("PlayerGreen");
        Players.AddRange(PlayerGreen);
    }

    void PlayerBlue_revival_function()
    {
        GameObject[] PlayerBlue = GameObject.FindGameObjectsWithTag("PlayerBlue");
        Players.AddRange(PlayerBlue);
    }

    void PlayerRed_revival_function() 
    {
        GameObject[] PlayerRed = GameObject.FindGameObjectsWithTag("PlayerRed");
        Players.AddRange(PlayerRed);
    }
}