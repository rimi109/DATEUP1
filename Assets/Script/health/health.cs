using UnityEngine;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    [Header("heartのGameObjectを取得"), SerializeField]
    private List<GameObject>   healthList = new List<GameObject>();

    [Header("PlayerのTransfromを取得"), SerializeField]
    private Transform          playerTransfrom;

    [Header("GameOverSeceChangeを取得"), SerializeField]
    private GameOverSeceChange gameOverSeceChange;

    [Header("PlayerBaseを取得"), SerializeField]
    private PlayerBase         playerBase;


    [Tooltip("Playerが死んだときに立てる")]
    private bool               playerDieGameOverFlag;


    [Tooltip("heartを表示するpositionXを設定")]
    private const int          HEALTH_POSITION_X = 10;

    [Tooltip("heartを表示するpositionYを設定")]
    private const int          HEALTH_POSITION_Y = 15;

    [Tooltip("heartを表示するpositionZを設定")]
    private const int          HEALTH_POSITION_Z = 4;

    [Tooltip("Playerの死んだ時の初期hpを設定")]
    private const int          HEALTH_DEFAUIT = 1;


    void Start()
    {
        playerDieGameOverFlag = false;
    }

    void Update()
    {

        for (int i = 0; i < healthList.Count; ++i)
        {
            healthList[i].transform.rotation = Camera.main.transform.rotation;
            healthList[i].transform.position = new Vector3(playerTransfrom.transform.position.x - HEALTH_POSITION_X,
                                                        playerTransfrom.transform.position.y + HEALTH_POSITION_Y,
                                                        playerTransfrom.transform.position.z - HEALTH_POSITION_Z);

            healthList[i].transform.position = new Vector3(healthList[i].transform.position.x + (i * HEALTH_POSITION_X),
                                                       healthList[i].transform.position.y, healthList[i].
                                                       transform.position.z);
        }

        if (!playerDieGameOverFlag && playerBase.HealthCount <= 0)
        {
            gameOverSeceChange.GameOverCount();
            playerDieGameOverFlag = true;
        }
    }

    #region Playerの現在のHpを表示
    /// <summary>
    /// Playerの現在のHpを表示
    /// </summary>
    public void HealthFunction()
    {
        healthList[playerBase.HealthCount].SetActive(false);
    }
    #endregion

    #region Playerが生き返った時に呼ばれる関数
    /// <summary>
    /// Playerが生き返った時に呼ばれる関数
    /// </summary>
    public void PlayerRecoveryFunction()
    {
        playerDieGameOverFlag = false;
        healthList[playerBase.HealthCount - HEALTH_DEFAUIT].SetActive(true);
        gameOverSeceChange.GameOverMinus();
    }
    #endregion
}