using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.ProBuilder.Shapes;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem particle;

    public GameObject anime;

    private bool Anime;
    private bool EffectStart;
    private bool Effect;

    private NavMeshAgent agent;
    public CapsuleCollider col;
    public Renderer MeshRen;

    [Header("PlayerManagerのScriptを取得"), SerializeField]
    private PlayerManager Player_Manager;

    
    private float EffectTime;
    private float AnimeTime;
    private const float Enemy_Move_Speed = 10.0f;
    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing Date_Array;

    [Tooltip("Enemyの移動スピードのデータ番号を設定")]
    private const int ENEMY_MOVE_SPEED_INDEX = 6;
    void Start()
    {
        EffectTime = 0.0f;
        AnimeTime = 0.0f;

        Anime = false;
        EffectStart = false;
        Effect = false;
        col.enabled = false;

        agent = GetComponent<NavMeshAgent>();
        Player_Manager = FindObjectOfType<PlayerManager>();
        Date_Array = GameObject.FindObjectOfType<CSVProcessing>();
    }

    void Update()
    {
        AnimeTime += 1.0f * Time.deltaTime;

        if (!Anime)
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

        Enemy_Move();

    }

    #region　自分から一番近いPlayerを追尾する
    /// <summary>
    /// 自分から一番近いPlayerを追尾する
    /// </summary>
    private void Enemy_Move()
    {
        float closestPlayerDistance = float.MaxValue;
        Transform closestPlayer = null;

        for (int i = 0; i < Player_Manager.Players.Count; i++)
        {
            float playerDistance = Vector3.Distance(this.transform.position, Player_Manager.Players[i].transform.position);

            if (playerDistance < closestPlayerDistance)
            {
                closestPlayerDistance = playerDistance;
                closestPlayer = Player_Manager.Players[i];
            }
        }

        if (closestPlayer != null)
        {
            agent.destination = closestPlayer.transform.position;
            agent.speed = Date_Array.Monster_Data[ENEMY_MOVE_SPEED_INDEX].Speed;
        }
    }
    #endregion

}