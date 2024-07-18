using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject victoryText;
    public GameObject gameOverText; // Reference to the game over text
    public GameObject pickupParent;
    private int totalPickups = 0;
    public int winningScore = 4;
    public bool isGameOver = false; // Changed to public
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Cannot have more than one instance of [GameManager] in the scene! Deleting extra copy");
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        score = 0;
        UpdateScoreText();
        victoryText.SetActive(false);
        gameOverText.SetActive(false); // Ensure game over text is initially inactive
        totalPickups = pickupParent.transform.childCount;
    }
    public void UpdateScore(int amount)
    {
        if (!isGameOver)
        {
            score += amount;
            UpdateScoreText();
            if (score >= winningScore)
            {
                GameWin();
            }
        }
    }
    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
    public void GameWin()
    {
        isGameOver = true;
        victoryText.SetActive(true);
        // Implement any other win game logic here
    }
    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Game Over");
            gameOverText.SetActive(true); // Activate the game over text
            // Implement game over logic if needed
        }
    }
    public void PickupCollected()
    {
        if (!isGameOver)
        {
            totalPickups--;
            if (totalPickups <= 0 && score < winningScore)
            {
                GameOver();
            }
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public int GetCurrentScore()
    {
        return score;
    }
}
