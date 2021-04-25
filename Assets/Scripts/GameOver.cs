using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private Text gameOver;
    public GameObject restart;
    void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
        restart.SetActive(false);
    }

    void Update()
    {
        if (GameController.isPlayerLose)
        {
            StopGame("Game Over");
        }
        else if (GameController.isPlayerWin)
        {
            StopGame("You Win");
        }
    }

    void StopGame(string messeg)
    {
        Time.timeScale = 0;
        gameOver.text = messeg;
        gameOver.enabled = true;
        restart.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
