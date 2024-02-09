using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{    [SerializeField]
    private GameObject[] health_;

    [SerializeField]
    private Transform Green_Player;

    [SerializeField]
    private Camera Main_Camera;

    [SerializeField]
    private  int Health_Count;

    [SerializeField]
    private Color Healt_Color;

    [SerializeField]
    private GameOverSeceChange gameOverSeceChange;

    [Tooltip("")]
    private bool GameOverCount;

    [Header(""), SerializeField]
    private PlayerScript PlayerGreenDieAnimator;

    void Start()
    {
        GameOverCount = false;
    }

    void Update()
    {
        for (int i = 0; i < health_.Length; ++i)
        {
            health_[i].transform.rotation = Camera.main.transform.rotation;
            health_[i].transform.position = new Vector3(Green_Player.transform.position.x - 10, Green_Player.transform.position.y + 15, Green_Player.transform.position.z - 4);
            health_[i].transform.position = new Vector3(health_[i].transform.position.x + (i * 10), health_[i].transform.position.y,  health_[i].transform.position.z);
        }

        if (!GameOverCount && Health_Count < 0)
        {
            gameOverSeceChange.GameOver_Count();
            GameOverCount = true;
            PlayerGreenDieAnimator.PlayerDieAnimator();
        }

        Debug.Log(Health_Count);
    }

    public void Health_Function()
    {
        health_[Health_Count].SetActive(false);
        Health_Count -= 1;
    }

    public void Player_Recovery_Function()
    {
        GameOverCount = false;
        Health_Count += 1;
        health_[Health_Count].SetActive(true);
        gameOverSeceChange.GameOver_Minus();
    }
}
