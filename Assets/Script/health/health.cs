using UnityEngine;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    [Header("heart‚ÌGameObject‚ðŽæ“¾"),SerializeField]
    private List<GameObject>    health = new List<GameObject>();

    [Header("Player‚ÌTransfrom‚ðŽæ“¾"),SerializeField]
    private Transform           playerTransfrom;

    [Header("GameOverSeceChange‚ðŽæ“¾"),SerializeField]
    private GameOverSeceChange  gameOverSeceChange;

    [Header("PlayerBase‚ðŽæ“¾"), SerializeField]
    private PlayerBase          playerBase;

    [Tooltip("Player‚ªŽ€‚ñ‚¾‚Æ‚«‚É—§‚Ä‚é")]
    private bool                playerDieGameOverFlag;

    [Tooltip("")]
    private const int           HEALTH_POSITION_X = 10;

    [Tooltip("")]
    private const int           HEALTH_POSITION_Y = 15;

    [Tooltip("")]
    private const int           HEALTH_POSITION_ = 4;


    void Start()
    {
        playerDieGameOverFlag = false;
    }

    void Update()
    {

        for (int i = 0; i < health.Count; ++i)
        {
            health[i].transform.rotation = Camera.main.transform.rotation;
            health[i].transform.position = new Vector3(playerTransfrom.transform.position.x - HEALTH_POSITION_X,
                                                        playerTransfrom.transform.position.y + HEALTH_POSITION_Y,
                                                        playerTransfrom.transform.position.z - HEALTH_POSITION_);

            health[i].transform.position = new Vector3(health[i].transform.position.x + (i * HEALTH_POSITION_X),
                                                                      health[i].transform.position.y, health[i].
                                                                                          transform.position.z);
        }

        if (!playerDieGameOverFlag && playerBase.healthCount <= 0)
        {
            gameOverSeceChange.GameOverCount();
            playerDieGameOverFlag = true;
        }
    }

    public void HealthFunction()
    {
        health[playerBase.healthCount].SetActive(false);
    }

    public void PlayerRecoveryFunction()
    {
        playerDieGameOverFlag = false;
        health[playerBase.healthCount - 1].SetActive(true);
        gameOverSeceChange.GameOverMinus();
    }
}
