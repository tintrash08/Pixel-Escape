using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameScreenUI;
    public static bool IsGamePaused = false;
    public GameObject pauseButton;

    public GameObject tapToStartText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI scoreTextOnGameOverScreen;
    public TextMeshProUGUI highscoreTextOnGameOverScreen;

    public GameObject gameOverMenuUI;
    int score = 0;
    int highscore = 0;

    public GameObject[] healthBar;

    private void Start()
    {
        highscore = PlayerPrefs.HasKey(CommonConstants.highScorePlayerPref) ? PlayerPrefs.GetInt(CommonConstants.highScorePlayerPref) : 0;
        highscoreText.text = "Highscore: " + highscore.ToString();
        pauseButton.SetActive(true);
    }
    public void modifyActiveStatusOfElements(GameObject gameObject, bool status)
    {
        gameObject.SetActive(status);
    }

    public void increaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if(score > highscore)
        {
            highscore = score;
            highscoreText.text = "Highscore: " + highscore.ToString();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void RetryButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt(CommonConstants.highScorePlayerPref, highscore);
        scoreTextOnGameOverScreen.text = "Score: " + score.ToString();
        highscoreTextOnGameOverScreen.text = "Highscore: " + highscore.ToString();
        gameOverMenuUI.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void decreaseHealth(int health)
    {
        for (int i=1; i<healthBar.Length+1; i++)
        {
            if (i <= health)
            {
                healthBar[i-1].SetActive(true);
            }
            else
            {
                healthBar[i-1].SetActive(false);
            }
        }

    }

}
