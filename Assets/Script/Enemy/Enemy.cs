using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.ProBuilder.Shapes;

public class Enemy : MonoBehaviour
{

    [Header(""),SerializeField]
    private ParticleSystem     parTicle;

    [Tooltip("")]
    private GameObject         anime;

    [Tooltip("")]
    private bool               animeFlag;

    [Tooltip("")]
    private bool               effectStartFlag;

    [Tooltip("")]
    private bool               effectFlag;

    [Tooltip("")]
    private NavMeshAgent       agent;

    [Tooltip("")]
    private MeshRenderer meshRenderer;

    [Header(""),SerializeField]
    private CapsuleCollider    capsuleCollider;

    [Header("PlayerManagerのScriptを取得"), SerializeField]
    private PlayerManager      playerManager;

    [Tooltip("")]
    private float              effectTime;
      
    [Tooltip("")]
    private float              animeTime;

    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing      dateArray;

    [Tooltip("Enemyの移動スピードのデータ番号を設定")]
    private const int          ENEMY_MOVE_SPEED_INDEX = 6;
    void Start()
    {
        effectTime = 0.0f;
        animeTime  = 0.0f;

        animeFlag = false;
        effectStartFlag = false;
        effectFlag = false;
        capsuleCollider.enabled = false;

        agent = GetComponent<NavMeshAgent>();
        playerManager = FindObjectOfType<PlayerManager>();
        dateArray = GameObject.FindObjectOfType<CSVProcessing>();
    }

    void Update()
    {
        animeTime += 1.0f * Time.deltaTime;

        if (!animeFlag)
        {
            GameObject newAnim = Instantiate(anime);
            newAnim.transform.position = new Vector3(this.transform.position.x,
                                                     this.transform.position.y + 10,
                                                     this.transform.position.z);
            animeFlag = true;
        }

        if (!effectFlag && animeTime >= 2.0f)
        {
            if (!effectStartFlag)
            {
                ParticleSystem newParticle = Instantiate(parTicle);
                newParticle.transform.position = this.transform.position;
                newParticle.Play();
                Destroy(newParticle, 1.0f);
                effectTime += 1.0f * Time.deltaTime;
                effectFlag = true;
           
                if (effectTime >= 1.0f)
                {
                    effectStartFlag = true;
                }
            }
        }

        if (!effectStartFlag && !effectFlag)
            return;

        capsuleCollider.enabled = true;

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

        for (int i = 0; i < playerManager.Players.Count; i++)
        {
            float playerDistance = Vector3.Distance(this.transform.position, playerManager.Players[i].transform.position);

            if (playerDistance < closestPlayerDistance)
            {
                closestPlayerDistance = playerDistance;
                closestPlayer = playerManager.Players[i];
            }
        }

        if (closestPlayer != null)
        {
            agent.destination = closestPlayer.transform.position;
            agent.speed = dateArray.monsterData[ENEMY_MOVE_SPEED_INDEX].Speed;
        }
    }
    #endregion

}