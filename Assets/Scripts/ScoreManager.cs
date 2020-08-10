using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static int score;        // The player's score.
    public static int money;        // The Player's money.


    public Text scoreText;      
    public Text moneyText;               


    void Awake()
    {
        // Reset the score.
        score = 0;
        money = 100;
    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        scoreText.text = "Score: " + score;
        moneyText.text = "Money: " + money;
    }
}