using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{   
    [SerializeField] private int scoreToWin = 5;

    private int player1Score = 0;
    private int player2Score = 0;

    public Text Player1ScoreText;
    public Text Player2ScoreText;

    public void Player1Goal()
    {
        player1Score++;
        Player1ScoreText.text = player1Score.ToString();
        CheckScore();

    }

    public void Player2Goal()
    {
        player2Score++;
        Player2ScoreText.text = player2Score.ToString();
        CheckScore() ;
    }

    public void CheckScore()
    {
        if (player1Score == scoreToWin || player2Score == scoreToWin)
        {
            SceneManager.LoadScene(2);
        }
    }



}
