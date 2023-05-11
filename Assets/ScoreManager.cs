using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score=0;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text finalScoreText;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void AddScore(int scr)
    {
        score += scr;
        Debug.Log("Score : " + score);
        scoreText.text = score.ToString();
    }

    public void ProcessGameOver()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = scoreText.text;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
