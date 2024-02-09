using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSeceChange : MonoBehaviour
{
    private int GameOverCount;

     void Start()
    {
        GameOverCount = 0;
    }

    private void Update()
    {
        if (GameOverCount == 3)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void GameOver_Count()
    {
        ++GameOverCount;
    }
    public void GameOver_Minus()
    {
        --GameOverCount;
    }
}
