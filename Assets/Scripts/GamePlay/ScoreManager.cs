using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int totalScore;

    [SerializeField]
    private TMP_Text scoreText;

    private void Start()
    {
        Instance = this;
        totalScore = 0;
    }

    private void Update()
    {
        scoreText.text = $"Score: {totalScore.ToString()}";
    }

    public void Hit(int score)
    {
        totalScore += score;
    }
}
