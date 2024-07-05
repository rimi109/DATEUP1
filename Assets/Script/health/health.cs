using UnityEngine;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    [Header(""),SerializeField]
    private List<GameObject> Health_ = new List<GameObject>();

    [Header(""),SerializeField]
    private Transform Player_Transfrom;

    [Header(""),SerializeField]
    private Color Healt_Color;

    [Header(""),SerializeField]
    private GameOverSeceChange gameOverSeceChange;

    [Tooltip("")]
    private bool GameOverCount;

    int Player_Health;

    //[Header(""), SerializeField]
    //private PlayerGreen PlayerGreenDieAnimator;

    void Start()
    {
        GameOverCount = false;
    }

    void Update()
    {
        for (int i = 0; i < Health_.Count; ++i)
        {
            Health_[i].transform.rotation = Camera.main.transform.rotation;
            Health_[i].transform.position = new Vector3(Player_Transfrom.transform.position.x - 10, Player_Transfrom.transform.position.y + 15, Player_Transfrom.transform.position.z - 4);
            Health_[i].transform.position = new Vector3(Health_[i].transform.position.x + (i * 10), Health_[i].transform.position.y, Health_[i].transform.position.z);
        }

        if (!GameOverCount && Player_Health <= 0)
        {
            gameOverSeceChange.GameOver_Count();
            GameOverCount = true;
        }
    }

    public void Health_Function()
    {
        Health_[Player_Health].SetActive(false);
    }

    public void Player_Recovery_Function()
    {
        GameOverCount = false;
        Health_[Player_Health].SetActive(true);
        gameOverSeceChange.GameOver_Minus();
    }
}
