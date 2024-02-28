using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject gameOverScreen1;
    public GameObject gameOverScreen2;
    public GameObject gameOverScreen3;
    public GameObject pauseScreen;
    public AudioSource point;
    public AudioSource die;
    public AudioSource pauseSound;
    public AudioSource backgroundScore;
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {

        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        point.Play();
        
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void gameOver()
    {
        Time.timeScale = 0;
        backgroundScore.Stop();
        if (playerScore == 0)
        {
            gameOverScreen.SetActive(true);
        }
        else if (playerScore >= 1 && playerScore <= 5)
        {
            gameOverScreen1.SetActive(true);
        }
        else if (playerScore  <= 10)
        {
            gameOverScreen2.SetActive(true);
        }
        else
        {
            gameOverScreen3.SetActive(true);
        }

    }
    public void dies()
    {
        die.Play();    }

}
