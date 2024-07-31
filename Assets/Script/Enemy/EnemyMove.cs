using UnityEngine.AI;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    [Tooltip("NavMeshAgentを取得")]
    private NavMeshAgent navMeshAgent;

    [Header("PlayerManagerのScriptを取得"), SerializeField]
    private PlayerManager playerManager;

    [Header("CSVからデータを取得"), SerializeField]
    private CSVProcessing dateArray;


    [Tooltip("Enemyの移動スピードのデータ番号を設定")]
    private const int ENEMY_MOVE_SPEED_INDEX = 6;

    // Start is called before the first frame update
    void Start()
    {
        dateArray = GameObject.FindObjectOfType<CSVProcessing>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    #region　自分から一番近いPlayerを追尾する
    /// <summary>
    /// 自分から一番近いPlayerを追尾する
    /// </summary>
    public void EnemyMoveFunction()
    {
        float closestPlayerDistance = float.MaxValue;
        Transform closestPlayer = null;

        for (int i = 0; i < playerManager.Players.Count; i++)
        {
            float playerDistance = Vector3.Distance(this.transform.position,
                                                    playerManager.Players[i].
                                                    transform.position);

            if (playerDistance < closestPlayerDistance)
            {
                closestPlayerDistance = playerDistance;
                closestPlayer = playerManager.Players[i];
            }
        }

        if (closestPlayer != null)
        {
            navMeshAgent.destination = closestPlayer.transform.position;
            navMeshAgent.speed = dateArray.monsterData[ENEMY_MOVE_SPEED_INDEX].Speed;
        }
    }
    #endregion

}
