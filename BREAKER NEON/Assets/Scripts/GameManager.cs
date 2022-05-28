﻿using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int finalScore = 0;
    private Ball ball;
    private int lives = 10;
    private TextMeshProUGUI textScore;
    private static int LOSE_WIN_SCENE = 1;
    private static int LEVEL_ONE_SCENE = 3;
    private bool resetOneTime;

    private void Awake()
    {
        int amountGameManagers = FindObjectsOfType<GameManager>().Length;
        if (amountGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        RestoreBallPosition();
        FinalScore();
        ResetValues();
    }

    private void RestoreBallPosition()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ball = FindObjectOfType<Ball>();
            ball.resetPosition();
        }
    }

    public void FinalScore()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        if (indexScene == LOSE_WIN_SCENE)
        {
            GameObject scoreTotal = GameObject.Find("scoreTotal");
            scoreTotal.GetComponent<TextMeshProUGUI>().text = finalScore.ToString();
            hideCanvas();
        }
    }

    private void ResetValues()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        if (indexScene == LEVEL_ONE_SCENE)
        {
            TextMeshProUGUI scoreCanvas = GameObject.Find("score").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI livesCanvas = GameObject.Find("lives").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI ScoreNumberCanvas = GameObject.Find("scoreNumber").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI LivesNumberCanvas = GameObject.Find("livesNumber").GetComponent<TextMeshProUGUI>();
            bool titles = scoreCanvas.text.Equals("") && livesCanvas.text.Equals("");
            bool titlesNumber = ScoreNumberCanvas.text.Equals("") && LivesNumberCanvas.text.Equals("");
            if (titles && titlesNumber)
            {
                this.lives = 10;
                this.finalScore = 0;
                FindObjectOfType<Score>().SetTotalScore(this.finalScore);
                FindObjectOfType<Health>().SetHealth(this.lives);
                scoreCanvas.text = "Score";
                livesCanvas.text = "Lives";
                ScoreNumberCanvas.text = this.finalScore.ToString();
                LivesNumberCanvas.text = this.lives.ToString();
                Debug.Log("una sola vez");
            }
        }
    }

    private void hideCanvas()
    {
        TextMeshProUGUI score = FindObjectOfType<Score>().GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI life = FindObjectOfType<Health>().GetComponent<TextMeshProUGUI>();
        score.text = "";
        life.text = "";
        GameObject textScore = GameObject.Find("score");
        GameObject textLives = GameObject.Find("lives");
        textScore.GetComponent<TextMeshProUGUI>().text = "";
        textLives.GetComponent<TextMeshProUGUI>().text = "";
    }

    /**
     * constructors
     */
    public void SetFinalScore(int score)
    {
        this.finalScore = score;
    }

    public int GetActualLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}