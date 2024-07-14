using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;
    public static int score = 0;

    void Start()
    {
        scoreText = GetComponentInChildren<Text>();
        scoreText.text = "score";
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }
}