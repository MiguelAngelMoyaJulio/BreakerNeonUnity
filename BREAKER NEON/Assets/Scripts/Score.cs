using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int totalScore = 0;
    private GameManager gameManager;
    private bool resetScore;
    private static int LEVEL_ONE_SCENE = 3;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = totalScore.ToString();
    }

    public void incrementScore(int score)
    {
        totalScore = totalScore + score;
        scoreText.text = totalScore.ToString();
        gameManager.SetFinalScore(totalScore);
    }

    public void SetTotalScore(int resetScore)
    {
        this.totalScore = resetScore;
    }
}