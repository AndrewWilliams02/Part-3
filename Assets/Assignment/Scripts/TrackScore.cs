using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class TrackScore : MonoBehaviour
{
    static int score; //Static variable to track score
    string scoreText; //Variable to convert score into string
    public TextMeshProUGUI scoreKeeper; //Variable to display score in text on screen

    //Function to update score mid-game
    void Update()
    {
        scoreText = "Score: " + score;
        scoreKeeper.text = scoreText;
    }

    //Public function for adding to score
    public static void UpdateScore()
    {
        score++;
    }
}