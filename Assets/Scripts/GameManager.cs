using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public TextMeshProUGUI playerScore;
    public GameObject ballPrefab;
    public GameObject endGame;
    public bool restartBall = false;
    public float time = 60;

    // Start is called before the first frame update
    void Start()
    {
        RespawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        StartTime();
        Time.timeScale = 1;
        if (Mathf.Round(time) == 0)
        {
            EndGame();
        }
    }

    public void StartTime()
    {
        time -= Time.deltaTime;
        timeText.text = "Time : " + Mathf.Round(time);
        if (Mathf.Round(time) <= 10)
        {
            timeText.color = Color.red;
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        endGame.SetActive(true);
        playerScore.SetText("Your " + scoreText.text);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartBall(bool restart)
    {
        restartBall = restart;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score;
    }

    public void RespawnBall()
    {
        Instantiate(ballPrefab, new Vector3(16.5f, 3.6f, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
    }
}
