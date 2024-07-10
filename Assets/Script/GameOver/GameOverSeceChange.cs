using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSeceChange : MonoBehaviour
{
    private int gameOverCounter;

    void Start()
    {
        gameOverCounter = 0;
    }

    private void Update()
    {
        if (gameOverCounter == 3)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void GameOverCount()
    {
        ++gameOverCounter;
    }
    public void GameOverMinus()
    {
        if (gameOverCounter == 0) return;

        --gameOverCounter;
    }
}
