using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public BirdScript bird;
    public AudioSource dingSFX;

    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        highScore = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (bird.birdIsAlive == true)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();

            if (dingSFX == null) dingSFX = gameObject.GetComponent<AudioSource>();
            dingSFX.Play();
            Debug.Log("Ding Sound");
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highscore", playerScore);
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}
